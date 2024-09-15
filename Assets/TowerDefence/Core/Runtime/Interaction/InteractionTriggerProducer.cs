using Common;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Interaction
{
    public class InteractionTriggerProducer : IInteractionTriggerProducer
    {
        private readonly EventProducer<ITriggerObserver> m_EventProducer = new();

        public void Attach(ITriggerObserver observer)
        {
            m_EventProducer.Attach(observer);
        }

        public void Detach(ITriggerObserver observer)
        {
            m_EventProducer.Detach(observer);        
        }

        public void OnEnter(GameObject gameObject)
        {
            m_EventProducer.NotifyAll(observer => observer.OnEnter(gameObject));
        }
        
        public void OnExit(GameObject gameObject)
        {
            m_EventProducer.NotifyAll(observer => observer.OnExit(gameObject));
        }
    }
}