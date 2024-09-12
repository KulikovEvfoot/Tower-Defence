using System;
using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class EntryObjectsNotifier : IDisposable
    {
        public event Action OnChange; 
        
        private readonly HashSet<int> m_Entries = new();
        private readonly InteractionFilter<IGameObjectEntity> m_InteractionFilter;
        private readonly IGameEntities m_GameEntities;
        
        public EntryObjectsNotifier(IInteractionObject interactionObject, IGameEntities gameEntities)
        {
            m_InteractionFilter =
                new InteractionFilter<IGameObjectEntity>(interactionObject, onEnter: OnEnter, onExit: OnExit);

            m_GameEntities = gameEntities;
        }
        
        public bool Has(int id)
        {
            if (!m_Entries.Contains(id))
            {
                return false;
            }

            return InternalHas(id);
        }

        public void Update()
        {
            int pointer = 0;
            Span<int> ids = stackalloc int[m_Entries.Count];
            
            foreach (var id in m_Entries)
            {
                if (InternalHas(id))
                {
                    continue;
                }

                ids[pointer] = id;
                pointer++;
            }

            for (int i = 0; i <= pointer; i++)
            {
                var id = ids[i];
                m_Entries.Remove(id);
            }

            if (pointer > 0)
            {
                OnChange?.Invoke();
            }
        }

        private bool InternalHas(int id)
        {
            var result = m_GameEntities.Get(id);
            return result.IsExist;
        }
        
        private void OnEnter(IGameObjectEntity entity)
        {
            if (m_Entries.Contains(entity.Id))
            {
                return;
            }

            m_Entries.Add(entity.Id);
            OnChange?.Invoke();
        }

        private void OnExit(IGameObjectEntity entity)
        {
            var isRemoved = m_Entries.Remove(entity.Id);
            if (isRemoved)
            {
                OnChange?.Invoke();
            }
        }

        public void Dispose()
        {
            m_InteractionFilter.Dispose();
        }
    }
}