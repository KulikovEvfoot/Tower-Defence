using System;
using System.Collections.Generic;

namespace Common
{
    public class EventProducer<T> : IEventProducer<T>
    {
        private readonly List<T> m_Observers = new();
        
        private List<T> m_CacheList = new();
        private bool m_HasObserversCountChanged;
        
        public void Attach(T observer)
        {
            if (m_Observers.Contains(observer))
            {
                return;
            }
            
            m_Observers.Add(observer);
            m_HasObserversCountChanged = true;
        }

        public void Detach(T observer)
        {
            m_Observers.Remove(observer);
            m_HasObserversCountChanged = true;
        }
        
        public void NotifyAll(Action<T> notification)
        {
            if (m_HasObserversCountChanged)
            {
                m_CacheList = new List<T>(m_Observers);
                m_HasObserversCountChanged = false;
            }

            foreach (var item in m_CacheList)
            {
                notification?.Invoke(item);
            }
        }
    }
}