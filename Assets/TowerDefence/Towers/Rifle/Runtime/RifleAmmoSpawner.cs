using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RifleAmmoSpawner
    {
        private RifleAmmoFactory m_AmmoFactory;
        private RifleAmmoConfigurator m_RifleAmmoConfigurator;

        public RifleAmmo Create(Vector3 position)
        {
            var bullet = m_AmmoFactory.Create();
            m_RifleAmmoConfigurator.Configure(bullet, position);
            return bullet;
        }
    }
}