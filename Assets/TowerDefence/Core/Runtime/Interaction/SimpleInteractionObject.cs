using UnityEngine;

namespace TowerDefence.Core.Runtime.Interaction
{
    public class SimpleInteractionObject : MonoBehaviour, IInteractionObject
    {
        private readonly InteractionTriggerProducer m_InteractionTriggerProducer = new();
     
        public IInteractionTriggerProducer InteractionTriggerProducer => m_InteractionTriggerProducer;
        public Collider Collider { get; private set; }

        public Vector3 GetInteractionPosition()
        { 
            return transform.position;
        }

        private void Awake()
        {
            Collider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            m_InteractionTriggerProducer.OnEnter(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            m_InteractionTriggerProducer.OnExit(other.gameObject);
        }
    }
}