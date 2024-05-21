using UnityEngine;

namespace TowerDefence.Runtime
{
    public class StubUnit : IUnit, IShotTarget
    {
        public Vector3 Position { get; set; }
        
        public int Hp { get; private set; }
        public bool IsAlive { get; private set; }

        public StubUnit(Vector3 position, int hp, bool isAlive = true)
        {
            Position = position;
            Hp = hp;
            IsAlive = isAlive;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
            {
                return;
            }
            
            if (!IsAlive)
            {
                return;
            }

            Hp -= damage;
            
            if (Hp <= 0)
            {
                IsAlive = false;
                Hp = 0;
            }
        }
    }
}