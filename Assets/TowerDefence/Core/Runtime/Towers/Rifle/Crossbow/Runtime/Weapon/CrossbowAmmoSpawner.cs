using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowAmmoSpawner
    {
        private readonly IPool<CrossbowAmmo> m_AmmoPool;

        public CrossbowAmmoSpawner(CrossbowAmmoFactory ammoFactory)
        {
            m_AmmoPool = new Pool<CrossbowAmmo>(ammoFactory.Create, SetActiveBullet);
        }

        public CrossbowAmmo Spawn()
        {
            var ammo = m_AmmoPool.Get();
            return ammo;
        }

        public void Despawn(CrossbowAmmo ammo)
        {
            m_AmmoPool.Return(ammo);
        }
        
        private void SetActiveBullet(CrossbowAmmo crossbowAmmo, bool isActive)
        {
            crossbowAmmo.SetActive(isActive);
        }
    }
}