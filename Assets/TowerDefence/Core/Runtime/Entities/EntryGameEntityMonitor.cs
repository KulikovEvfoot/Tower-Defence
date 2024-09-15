using System;
using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class EntryGameEntityMonitor : IDisposable
    {
        public event Action OnChange; 
        
        private readonly HashSet<int> m_Entries = new();
        private readonly InteractionFilter<IAliveGameObjectEntity> m_InteractionFilter;

        public IEnumerable<int> Entries => m_Entries;
        
        public EntryGameEntityMonitor(IInteractionObject interactionObject)
        {
            m_InteractionFilter =
                new InteractionFilter<IAliveGameObjectEntity>(interactionObject, onEnter: OnEnter, onExit: OnExit);
        }
        
        private void OnEnter(IAliveGameObjectEntity aliveEntity)
        {
            if (m_Entries.Contains(aliveEntity.EntityId))
            {
                return;
            }

            aliveEntity.OnAliveChanged += EntityOnAliveChanged;
            
            m_Entries.Add(aliveEntity.EntityId);
            
            OnChange?.Invoke();
        }

        private void OnExit(IAliveGameObjectEntity aliveEntity)
        {
            aliveEntity.OnAliveChanged -= EntityOnAliveChanged;
            
            var isRemoved = m_Entries.Remove(aliveEntity.EntityId);
            
            if (isRemoved)
            {
                OnChange?.Invoke();
            }
        }

        private void EntityOnAliveChanged(IAliveGameObjectEntity aliveEntity, bool isAlive)
        {
            if (!isAlive)
            {
                OnExit(aliveEntity);
            }
        }

        public void Dispose()
        {
            m_InteractionFilter.Dispose();
        }
    }
}