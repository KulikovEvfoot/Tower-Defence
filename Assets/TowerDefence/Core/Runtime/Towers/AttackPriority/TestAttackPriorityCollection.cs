using System.Collections.Generic;
using System.Linq;
using Common;

namespace TowerDefence.Core.Runtime.Towers.AttackPriority
{
    public class TestAttackPriorityCollection<T> : IAttackPriorityCollection<T>
    {
        private readonly Dictionary<int, int> m_KeysPriority = new();
        private readonly SortedDictionary<int, T> m_SortedItems = new();
        private readonly HashSet<T> m_Items = new();
        
        private readonly IdFactory m_IdFactory = new();

        public bool HasNext()
        {
            return m_KeysPriority.Count > 0;
        }

        public bool Has(int id)
        {
            return m_KeysPriority.ContainsKey(id);
        }

        public bool Has(T item)
        {
            return m_Items.Contains(item);
        }

        public T GetNext()
        {
            return m_SortedItems.First().Value;
        }
        
        public void Add(int id, T item)
        {
            var priority = m_IdFactory.CreateNext() * -1;
            m_KeysPriority.Add(id, priority);
            m_SortedItems.Add(priority, item);
            m_Items.Add(item);
        }

        public void Remove(int id)
        {
            if (!m_KeysPriority.Remove(id, out var priority))
            {
                return;
            }

            var item = m_SortedItems[priority];
            m_Items.Remove(item);
            m_SortedItems.Remove(priority);
        }

        public void Clear()
        {
            m_KeysPriority.Clear();
            m_SortedItems.Clear();
            m_Items.Clear();
        }
    }
}