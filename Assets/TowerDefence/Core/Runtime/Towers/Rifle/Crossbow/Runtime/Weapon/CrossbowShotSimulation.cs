using System.Runtime.CompilerServices;
using UnityEngine;

// [assembly:InternalsVisibleTo("TowerDefence.Towers.Rifle.Tests")]
namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    internal class CrossbowShotSimulation
    {
        private const float m_DefaultSpeed = 1;
        
        private readonly Vector3 m_SenderPosition;
        private readonly float m_Time;

        private float m_TimeCounter;

        internal IShotTarget Target { get; set; }
        internal IAmmo Ammo { get; }
        internal bool IsCompleted { get; private set; }

        internal CrossbowShotSimulation(
            Vector3 senderPosition,
            IShotTarget target,
            IAmmo ammo,
            float ammoSpeed = m_DefaultSpeed)
        {
            m_SenderPosition = senderPosition;
            Target = target;
            Ammo = ammo;
            
            var distance = Vector3.Distance(m_SenderPosition, Target.Position);
            m_Time = distance / ammoSpeed;
        }

        internal void Move(float deltaTime)
        {
            if (IsCompleted)
            {
                return;
            }
            
            m_TimeCounter += deltaTime;
            var progress = m_TimeCounter / m_Time;
            Ammo.Position = Vector3.Lerp(m_SenderPosition, Target.Position, progress);

            IsCompleted = progress >= 1;
        }
    }
}