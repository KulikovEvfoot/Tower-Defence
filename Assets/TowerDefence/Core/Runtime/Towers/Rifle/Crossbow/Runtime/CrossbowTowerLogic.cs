using System;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerLogic : ITowerLogic, IDisposable
    {
        private readonly IGameEntities m_GameEntities;
        private readonly CrossbowWeapon m_CrossbowWeapon;
        private readonly CrossbowTowerInfoExpert m_InfoExpert;
        private readonly EntryGameEntityMonitor m_EntryGameEntityMonitor;
        
        private bool m_IsActive;
        
        public CrossbowTowerLogic(
            IInteractionObject interactionObject,
            CrossbowTowerInfoExpert infoExpert,
            CrossbowWeapon crossbowWeapon,
            IGameEntities gameEntities)
        {
            m_GameEntities = gameEntities;
            m_InfoExpert = infoExpert;
            m_CrossbowWeapon = crossbowWeapon;
            m_EntryGameEntityMonitor = new EntryGameEntityMonitor(interactionObject);
        }

        public void SetActive(bool isActive)
        {
            if (m_IsActive == isActive)
            {
                return;
            }
            
            m_IsActive = isActive;
            
            if (isActive)
            {
                m_InfoExpert.AimData.OnAimTaken += OnAimTaken;
                m_InfoExpert.ReloadData.OnReloaded += OnWeaponReloaded;
                m_InfoExpert.ReloadData.OnOutOfAmmo += OnWeaponOutAmmo;
                
                m_EntryGameEntityMonitor.OnChange += OnEntryGameEntityChange;
            }
            else
            {
                m_InfoExpert.AimData.OnAimTaken -= OnAimTaken;
                m_InfoExpert.ReloadData.OnReloaded -= OnWeaponReloaded;
                m_InfoExpert.ReloadData.OnOutOfAmmo -= OnWeaponOutAmmo;
                
                m_EntryGameEntityMonitor.OnChange -= OnEntryGameEntityChange;
            }
        }

        private void OnAimTaken(IShotTarget target)
        {
            Update();
        }

        private void OnWeaponReloaded()
        {
            Update();
        }

        private void OnWeaponOutAmmo()
        {
            Update();
        }

        private void Update()
        {
            if (!m_InfoExpert.ReloadData.HasAmmo())
            {
                m_CrossbowWeapon.Reload();
                Debug.Log("reload");
                return;
            }

            var toAttack = m_InfoExpert.AttackPriority;
            if (toAttack.HasNext())
            {
                var target = toAttack.GetNext();
                m_InfoExpert.CurrentTarget = target;
                m_CrossbowWeapon.TakeAim(target);
                Debug.Log("Take aim");
            }
            else
            {
                m_InfoExpert.CurrentTarget = null;
            }

            if (m_InfoExpert.IsAimTaken())
            {
                Debug.Log("shot");
                m_CrossbowWeapon.Shot(m_InfoExpert.CurrentTarget);
                return;
            }
            
            Debug.Log("idle");
        }

        //test logic, to first iteration
        private void OnEntryGameEntityChange()
        {
            var toAttack = m_InfoExpert.AttackPriority;
            toAttack.Clear();
            
            foreach (var entryId in m_EntryGameEntityMonitor.Entries)
            {
                var entityResult = m_GameEntities.Get(entryId);
                if (!entityResult.IsExist)
                {
                    continue;
                }

                var entity = entityResult.Object;
                if (entity is not IShotTarget shotTarget)
                {
                    continue;
                }
                
                toAttack.Add(entryId, shotTarget);
            }
            
            Update();
        }

        public void Dispose()
        {
            m_EntryGameEntityMonitor.OnChange -= OnEntryGameEntityChange;
            
            m_InfoExpert.AimData.OnAimTaken -= OnAimTaken;
            m_InfoExpert.ReloadData.OnReloaded -= OnWeaponReloaded;
            m_InfoExpert.ReloadData.OnOutOfAmmo -= OnWeaponOutAmmo;
        }
    }
}