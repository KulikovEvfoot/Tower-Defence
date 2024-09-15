using System;
using System.Collections.Generic;
using Common;
using TowerDefence.Core.Runtime.Towers.Aim;
using TowerDefence.Core.Runtime.Towers.Reload;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowWeapon : IShotStrategy, ICanTakeAim, ICanReload, IDisposable
    {
        private readonly CrossbowAmmoSpawner m_CrossbowAmmoSpawner;
        private readonly CrossbowAmmoAnchorPoint m_CrossbowAmmoAnchorPoint;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly CrossbowAmmoViewConfigurator m_CrossbowAmmoViewConfigurator;
        private readonly TowerRecharger m_TowerRecharger;
        private readonly TowerAim m_TowerAim;
        
        private readonly List<CrossbowShotSimulation> m_Simulations = new();

        internal CrossbowWeapon(
            CrossbowAmmoSpawner crossbowAmmoSpawner,
            CrossbowAmmoAnchorPoint anchorPoint,
            UpdateMaster updateMaster,
            TowerRecharger towerRecharger,
            TowerAim towerAim)
        {
            m_CrossbowAmmoSpawner = crossbowAmmoSpawner;
            m_CrossbowAmmoAnchorPoint = anchorPoint;
            m_UpdateMaster = updateMaster;
            m_TowerRecharger = towerRecharger;
            m_TowerAim = towerAim;
            
            m_CrossbowAmmoViewConfigurator = new CrossbowAmmoViewConfigurator();
            
            m_UpdateMaster.OnUpdate += UpdateAmmoPosition;
        }
        
        public void Reload()
        {
            m_TowerRecharger.Reload();
        }

        public void TakeAim(IShotTarget target)
        {
            m_TowerAim.TakeAim(target);
        }

        public void Shot(IShotTarget target)
        {
            if (!m_TowerRecharger.HasAmmo())
            {
                return;
            }
            
            var ammo = m_CrossbowAmmoSpawner.Spawn();
            m_CrossbowAmmoViewConfigurator.Configure(m_CrossbowAmmoAnchorPoint, ammo);
            var simulation = new CrossbowShotSimulation(target, ammo);
            m_Simulations.Add(simulation);

            m_TowerRecharger.Use();
        }

        private void UpdateAmmoPosition()
        {
            var count = m_Simulations.Count;
            
            for (int i = count - 1; i >= 0; i--)
            {
                var simulation = m_Simulations[i];
                simulation.Move(Time.deltaTime);
                if (simulation.IsCompleted)
                {
                    m_Simulations.RemoveAt(i);
                }
            }
        }

        public void Dispose()
        {
            m_UpdateMaster.OnUpdate -= UpdateAmmoPosition;
        }
    }
}