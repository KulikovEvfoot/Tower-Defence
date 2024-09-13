using System;
using Services.Timer.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Balance;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerLogic : ITowerLogic, IDisposable
    {
        private readonly IInteractionObject m_InteractionObject;
        private readonly IShotStrategy m_ShotStrategy;
        private readonly IGlobalTimer m_GlobalTimer;
        private readonly EntryObjectsNotifier m_EntryObjectsNotifier;

        private IShotTarget m_CurrentShotTarget;

        private bool m_IsActive;

        public CrossbowTowerLogic(IInteractionObject interactionObject, IShotStrategy shotStrategy, IGameEntities gameEntities)
        {
            m_InteractionObject = interactionObject;
            m_ShotStrategy = shotStrategy;
            m_EntryObjectsNotifier = new EntryObjectsNotifier(m_InteractionObject, gameEntities);
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
                m_EntryObjectsNotifier.OnChange += EntryObjectsObserverOnChange;
                m_EntryObjectsNotifier.Update();
            }
            else
            {
                m_EntryObjectsNotifier.OnChange -= EntryObjectsObserverOnChange;
            }

        }

        private void EntryObjectsObserverOnChange()
        {
            Debug.Log("FIRE");
        }

        public void Dispose()
        {
            m_EntryObjectsNotifier.OnChange -= EntryObjectsObserverOnChange;
        }
    }
}