using UnityEngine;

namespace TowerDefence.Runtime
{
    public class BulletConfigurator
    {
        public void Configure(Bullet bullet, Vector3 position)
        {
            bullet.Position = position;
        }
    }
}