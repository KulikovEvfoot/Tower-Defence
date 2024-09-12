namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IInteractionTriggerProducer
    {
        void Attach(ITriggerObserver observer);
        void Detach(ITriggerObserver observer);
    }
}