using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowShotSimulation
    {
        private const float m_DefaultSpeed = 1f;
        
        private readonly float m_Speed;
        
        public IShotTarget Target { get; set; }
        public IAmmo Ammo { get; }
        public bool IsCompleted { get; private set; }

        public CrossbowShotSimulation(
            IShotTarget target,
            IAmmo ammo,
            float ammoSpeed = m_DefaultSpeed)
        {
            Target = target;
            Ammo = ammo;

            m_Speed = ammoSpeed;
        }

        public void Move(float deltaTime)
        {
            if (IsCompleted)
            {
                return;
            }
            
            var step =  m_Speed * deltaTime;
            var ammoPosition = Ammo.Transform.position;
            ammoPosition = Vector3.MoveTowards(ammoPosition, Target.Position, step);
            
            Ammo.Transform.position = ammoPosition;
            Ammo.Transform.LookAt(Target.Position);
            
            if (Vector3.Distance(Ammo.Transform.position, Target.Position) < 0.001f)
            {
                IsCompleted = true; 
            }
        }
    }
}