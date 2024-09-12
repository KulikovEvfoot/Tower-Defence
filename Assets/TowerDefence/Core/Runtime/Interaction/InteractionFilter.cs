using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class InteractionFilter<T> : ITriggerObserver, IDisposable
    {
        private readonly IInteractionObject m_InteractionObject;
        private readonly Action<T> m_OnEnter;
        private readonly Action<T> m_OnExit;

        public InteractionFilter(
            IInteractionObject interactionObject,
            Action<T> onEnter,
            Action<T> onExit)
        {
            m_InteractionObject = interactionObject;
            m_OnEnter = onEnter;
            m_OnExit = onExit;

            m_InteractionObject.InteractionTriggerProducer.Attach(this);
        }

        public void OnEnter(GameObject input)
        {
            if (!input.TryGetComponent<T>(out var item))
            {
                return;
            }
            
            m_OnEnter?.Invoke(item);
        }

        public void OnExit(GameObject output)
        {
            if (!output.TryGetComponent<T>(out var item))
            {
                return;
            }
            
            m_OnExit?.Invoke(item);
        }

        public void Dispose()
        {
            m_InteractionObject.InteractionTriggerProducer.Detach(this);
        }
    }
}