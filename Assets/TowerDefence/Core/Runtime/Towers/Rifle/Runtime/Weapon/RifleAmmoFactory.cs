using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoFactory
    {
        private readonly RifleAmmoView m_RifleAmmoAsset;

        public RifleAmmoFactory(RifleAmmoView rifleAmmoAsset)
        {
            m_RifleAmmoAsset = rifleAmmoAsset;
        }

        internal RifleAmmo Create()
        {
            var view = Object.Instantiate(m_RifleAmmoAsset);
            return new RifleAmmo(view);
        }
    }
}