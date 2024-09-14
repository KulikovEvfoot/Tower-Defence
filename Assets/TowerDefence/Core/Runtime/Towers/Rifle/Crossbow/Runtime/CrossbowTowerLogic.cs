using System;
using Common.FSM;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerLogic : ITowerLogic, IDisposable
    {
        private readonly IGameEntities m_GameEntities;
        private readonly IAttackPriorityCollection<IShotTarget> m_AttackPriorityCollection;
        private readonly EntryGameEntityMonitor m_EntryGameEntityMonitor;

        private readonly CrossbowTowerInfoExpert m_InfoExpert;
        private readonly SimpleStateMachine m_StateMachine;

        private bool m_IsActive;

        public CrossbowTowerLogic(
            IInteractionObject interactionObject,
            CrossbowWeapon crossbowWeapon,
            IGameEntities gameEntities,
            IAttackPriorityCollection<IShotTarget> attackPriorityCollection,
            CrossbowTowerInfoExpert infoExpert)
        {
            m_GameEntities = gameEntities;
            m_AttackPriorityCollection = attackPriorityCollection;
            m_InfoExpert = infoExpert;
            m_EntryGameEntityMonitor = new EntryGameEntityMonitor(interactionObject, gameEntities);

            m_InfoExpert.AimData.OnAimTaken += OnAimTaken;
            m_InfoExpert.ReloadData.OnReloaded += OnWeaponReloaded;
            m_InfoExpert.ReloadData.OnOutOfAmmo += OnWeaponOutAmmo;
            
            var idleState = new CrossbowTowerIdleState();
            var aimState = new CrossbowTowerWeaponAimingState(crossbowWeapon, crossbowWeapon);
            var attackState = new CrossbowTowerAttackState(crossbowWeapon, m_AttackPriorityCollection);
            
            m_StateMachine = new SimpleStateMachine(
                states: new IState[]
                {
                    idleState,
                    aimState,
                    attackState
                },
                transitions: new Transition[]
                {
                    //to idle
                    new Transition(from: typeof(CrossbowTowerWeaponAimingState), to: typeof(CrossbowTowerIdleState), 
                        condition: () => !m_InfoExpert.HasEnemyInRange()),
                    
                    new Transition(from: typeof(CrossbowTowerAttackState), to: typeof(CrossbowTowerIdleState), 
                        condition: () => !m_InfoExpert.HasEnemyInRange()),
                    
                    //to aim
                    new Transition(from: typeof(CrossbowTowerIdleState), to: typeof(CrossbowTowerWeaponAimingState), 
                        condition: m_InfoExpert.HasEnemyInRange),
                    
                    new Transition(from: typeof(CrossbowTowerAttackState), to: typeof(CrossbowTowerWeaponAimingState), 
                        condition: () => !m_InfoExpert.IsAimTaken()),
                    
                    //to attack
                    new Transition(from: typeof(CrossbowTowerWeaponAimingState), to: typeof(CrossbowTowerAttackState), 
                        condition: () => m_InfoExpert.IsAimTaken() && m_InfoExpert.ReloadData.HasAmmo()),
                });
            
            m_StateMachine.Update();
        }

        private void OnWeaponReloaded()
        {
            UpdateFsm();
        }

        private void OnWeaponOutAmmo()
        {
            UpdateFsm();
        }

        private void OnAimTaken(IShotTarget target)
        {
            UpdateFsm();
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
                m_EntryGameEntityMonitor.OnChange += EntryGameEntityObserverOnChange;
                m_EntryGameEntityMonitor.Update();
            }
            else
            {
                m_EntryGameEntityMonitor.OnChange -= EntryGameEntityObserverOnChange;
            }
        }

        private void EntryGameEntityObserverOnChange()
        {
            foreach (var entryId in m_EntryGameEntityMonitor.Entries)
            {
                if (m_AttackPriorityCollection.Has(entryId))
                {
                    continue;
                }

                var entityResult = m_GameEntities.Get(entryId);
                if (!entityResult.IsExist)
                {
                    m_AttackPriorityCollection.Remove(entryId);
                    continue;
                }

                var entity = entityResult.Object;
                if (entity is not IShotTarget shotTarget)
                {
                    continue;
                }
                
                m_AttackPriorityCollection.Add(entryId, shotTarget);
                UpdateFsm();
            }
        }

        private void UpdateFsm()
        {
            m_StateMachine.Update();
        }

        public void Dispose()
        {
            m_EntryGameEntityMonitor.OnChange -= EntryGameEntityObserverOnChange;
            
            m_InfoExpert.AimData.OnAimTaken -= OnAimTaken;
            m_InfoExpert.ReloadData.OnReloaded -= UpdateFsm;
            m_InfoExpert.ReloadData.OnOutOfAmmo -= UpdateFsm;
        }
    }
}