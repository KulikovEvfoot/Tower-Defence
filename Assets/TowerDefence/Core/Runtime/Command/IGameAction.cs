namespace TowerDefence.Core.Runtime.Command
{
    public interface IGameAction
    {
        void Execute(IGameActionArgs args);
    }
}