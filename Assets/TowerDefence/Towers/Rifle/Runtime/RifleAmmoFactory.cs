using Common;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RifleAmmoFactory
    {
        private readonly RifleAmmoView m_RifleAmmoAsset;
        private readonly IPool<RifleAmmoView> m_ViewPool;

        public RifleAmmoFactory(RifleAmmoView rifleAmmoAsset)
        {
            m_RifleAmmoAsset = rifleAmmoAsset;
            m_ViewPool = new Pool<RifleAmmoView>(InstantiateBullet, SetActiveBullet);
        }

        public RifleAmmo Create()
        {
            var view = m_ViewPool.Get();
            var bullet = new RifleAmmo(view);
            return bullet;
        }

        private RifleAmmoView InstantiateBullet()
        {
            return Object.Instantiate(m_RifleAmmoAsset);
        }

        private void SetActiveBullet(RifleAmmoView rifleAmmo, bool isActive)
        {
            rifleAmmo.SetActive(isActive);
        }
    }
}