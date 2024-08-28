using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoSpawner
    {
        private readonly IPool<RifleAmmo> m_AmmoPool;

        public RifleAmmoSpawner(RifleAmmoFactory ammoFactory)
        {
            m_AmmoPool = new Pool<RifleAmmo>(ammoFactory.Create, SetActiveBullet);
        }

        public RifleAmmo Spawn()
        {
            var ammo = m_AmmoPool.Get();
            return ammo;
        }

        public void Despawn(RifleAmmo ammo)
        {
            m_AmmoPool.Return(ammo);
        }
        
        private void SetActiveBullet(RifleAmmo rifleAmmo, bool isActive)
        {
            rifleAmmo.SetActive(isActive);
        }
    }
}