using UnityEngine;

namespace TowerDefence.Runtime
{
    public class Bullet : IBullet
    {
        private readonly BulletView m_BulletView;

        public Vector3 Position
        {
            get => m_BulletView.Position;
            set => m_BulletView.Position = value;
        }

        public Bullet(BulletView view)
        {
            m_BulletView = view;
        }

        public void SetActive(bool isActive)
        {
            m_BulletView.SetActive(isActive);
        }
    }
}