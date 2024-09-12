using System;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Balance;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerLogic : ITowerLogic, IDisposable
    {
        private readonly IInteractionObject m_InteractionObject;
        private readonly IShotStrategy m_ShotStrategy;
        private readonly CrossbowTowerConfig m_CrossbowTowerConfig;
        private readonly EntryObjectsNotifier m_EntryObjectsNotifier;

        private IShotTarget m_CurrentShotTarget;

        public CrossbowTowerLogic(IInteractionObject interactionObject, IShotStrategy shotStrategy, IGameEntities gameEntities)
        {
            m_InteractionObject = interactionObject;
            m_ShotStrategy = shotStrategy;
            m_EntryObjectsNotifier = new EntryObjectsNotifier(m_InteractionObject, gameEntities);
            
            m_EntryObjectsNotifier.OnChange += EntryObjectsObserverOnChange;
        }
        
        public void SetActive(bool isActive)
        {
            
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