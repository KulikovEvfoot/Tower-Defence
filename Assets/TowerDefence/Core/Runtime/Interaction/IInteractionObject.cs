using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IInteractionObject
    {
        IInteractionTriggerProducer InteractionTriggerProducer { get; }
        Vector3 GetInteractionPosition();
    }
}