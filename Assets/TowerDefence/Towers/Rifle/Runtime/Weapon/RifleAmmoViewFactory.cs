using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoViewFactory
    {
        private readonly RifleAmmoView m_RifleAmmoAsset;

        public RifleAmmoViewFactory(RifleAmmoView rifleAmmoAsset)
        {
            m_RifleAmmoAsset = rifleAmmoAsset;
        }

        internal RifleAmmoView Create()
        {
            return Object.Instantiate(m_RifleAmmoAsset);
        }
    }
}