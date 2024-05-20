using Common;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class BulletFactory : IBulletFactory
    {
        private readonly BulletView m_BulletAsset;
        private readonly IPool<Bullet> m_Pool;

        public BulletFactory(BulletView bulletAsset)
        {
            m_BulletAsset = bulletAsset;
            m_Pool = new Pool<Bullet>(InstantiateBullet, SetActiveBullet);
        }

        public Bullet Create()
        {
            return m_Pool.Get();
        }

        private Bullet InstantiateBullet()
        {
            var view = Object.Instantiate(m_BulletAsset);
            var bullet = new Bullet(view);
            return bullet;
        }

        private void SetActiveBullet(Bullet bullet, bool isActive)
        {
            bullet.SetActive(isActive);
        }
    }
}