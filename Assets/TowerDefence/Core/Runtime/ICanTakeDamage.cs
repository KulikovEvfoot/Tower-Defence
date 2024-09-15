namespace TowerDefence.Core.Runtime
{
    public interface IUnit : IHasTransform, ICanDie, ICanTakeDamage
    {
    }

    public interface ICanTakeDamage : IHasHp
    {
        void TakeDamage(int damage);
    }

    public interface ICanDie
    {
        bool IsAlive { get; }
    }
    
    public interface IHasHp
    { 
        public int Hp { get; }
    }
}