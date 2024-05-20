using UnityEngine;

namespace TowerDefence.Runtime
{
    public class BulletSpawner
    {
        private IBulletFactory m_BulletFactory;
        private BulletConfigurator m_BulletConfigurator;

        public IBullet Create(Vector3 position)
        {
            var bullet = m_BulletFactory.Create();
            m_BulletConfigurator.Configure(bullet, position);
            return bullet;
        }
    }
}