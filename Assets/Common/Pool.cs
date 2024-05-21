using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class Pool<T> : IPool<T>
    {
        private readonly Stack<T> m_Objects;
        private readonly Func<T> m_Factory;
        
        protected readonly Action<T, bool> m_SetActiveCall;

        protected T Create() => m_Factory.Invoke();

        public Pool(Func<T> factory, Action<T, bool> setActiveCall)
        {
            m_Objects = new Stack<T>();
            m_Factory = factory ?? throw new ArgumentNullException(nameof(factory));
            m_SetActiveCall = setActiveCall;
        }

        public T Get()
        {
            T item;
            ActivateItem(item = m_Objects.Any() ? m_Objects.Pop() : Create());
            return item;
        }

        public void Return(T item)
        {
            if (!ValidateItem(item))
            {
                Debug.LogError($"Item isn't valid: {nameof(item)}");
                return;
            }

            DeactivateItem(item);
            m_Objects.Push(item);
        }

        public virtual bool ValidateItem(T item) => item != null;
        public virtual void ActivateItem(T item) => m_SetActiveCall?.Invoke(item, true);
        public virtual void DeactivateItem(T item) => m_SetActiveCall?.Invoke(item, false);
    }
}