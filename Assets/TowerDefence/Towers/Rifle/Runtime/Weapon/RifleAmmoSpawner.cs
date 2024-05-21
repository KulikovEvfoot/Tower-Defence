using Common;

namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    internal class RifleAmmoSpawner
    {
        private readonly RifleAmmoViewConfigurator m_RifleAmmoViewConfigurator;
        private readonly IPool<RifleAmmoView> m_ViewPool;

        public RifleAmmoSpawner(RifleAmmoViewFactory ammoViewFactory, RifleAmmoViewConfigurator rifleAmmoViewConfigurator)
        {
            m_RifleAmmoViewConfigurator = rifleAmmoViewConfigurator;
            m_ViewPool = new Pool<RifleAmmoView>(ammoViewFactory.Create, SetActiveBullet);
        }

        public RifleAmmo Spawn()
        {
            var view = m_ViewPool.Get();
            m_RifleAmmoViewConfigurator.Configure(view);
            var rifleAmmo = new RifleAmmo(view);
            return rifleAmmo;
        }

        public void Despawn(RifleAmmo ammo)
        {
            m_ViewPool.Return(ammo.View);
        }
        
        private void SetActiveBullet(RifleAmmoView rifleAmmo, bool isActive)
        {
            rifleAmmo.SetActive(isActive);
        }
    }
}