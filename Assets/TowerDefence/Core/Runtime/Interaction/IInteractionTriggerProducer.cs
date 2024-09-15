namespace TowerDefence.Core.Runtime.Interaction
{
    public interface IInteractionTriggerProducer
    {
        void Attach(ITriggerObserver observer);
        void Detach(ITriggerObserver observer);
    }
}