using UnityEngine;

namespace TowerDefence.Core.Runtime.Interaction
{
    public interface IInteractionObject
    {
        IInteractionTriggerProducer InteractionTriggerProducer { get; }
        Vector3 GetInteractionPosition();
    }
}