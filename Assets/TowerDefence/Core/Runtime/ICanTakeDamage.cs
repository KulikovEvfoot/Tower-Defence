using UnityEngine;

namespace TowerDefence.Core.Runtime
{
    public interface IUnit : ICanMove, ICanDie, ICanTakeDamage
    {
    }

    public interface ICanMove
    {
        Vector3 Position { get; set; }
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