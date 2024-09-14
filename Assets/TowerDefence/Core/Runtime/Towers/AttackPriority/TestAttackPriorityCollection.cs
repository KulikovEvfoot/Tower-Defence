using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class TestAttackPriorityCollection<T> : IAttackPriorityCollection<T>
    {
        private readonly Dictionary<int, int> m_KeysPriority = new();
        private readonly SortedDictionary<int, T> m_ShotTargets = new();
        
        private readonly IdFactory m_IdFactory = new();

        public bool HasNext()
        {
            return m_KeysPriority.Count > 0;
        }

        public bool Has(int id)
        {
            return m_KeysPriority.ContainsKey(id);
        }
        
        public T GetNext()
        {
            return m_ShotTargets[0];
        }
        
        public void Add(int id, T item)
        {
            var priority = m_IdFactory.CreateNext() * -1;
            m_KeysPriority.Add(id, priority);
            m_ShotTargets.Add(priority, item);
        }

        public void Remove(int id)
        {
            if (!m_KeysPriority.Remove(id, out var priority))
            {
                return;
            }

            m_ShotTargets.Remove(priority);
        }
    }
}