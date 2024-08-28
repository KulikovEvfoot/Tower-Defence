using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class CrossbowAmmoFactory
    {
        private readonly CrossbowAmmoView m_CrossbowAmmoAsset;

        public CrossbowAmmoFactory(CrossbowAmmoView crossbowAmmoAsset)
        {
            m_CrossbowAmmoAsset = crossbowAmmoAsset;
        }

        internal CrossbowAmmo Create()
        {
            var view = Object.Instantiate(m_CrossbowAmmoAsset);
            return new CrossbowAmmo(view);
        }
    }
}