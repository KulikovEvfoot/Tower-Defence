using TowerDefence.Core.Runtime.Entities;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowAmmoFactory
    {
        private readonly IGameEntities m_GameEntities;
        private readonly CrossbowAmmoView m_CrossbowAmmoAsset;

        public CrossbowAmmoFactory(IGameEntities gameEntities, CrossbowAmmoView crossbowAmmoAsset)
        {
            m_GameEntities = gameEntities;
            m_CrossbowAmmoAsset = crossbowAmmoAsset;
        }

        internal CrossbowAmmo Create()
        {
            var view = Object.Instantiate(m_CrossbowAmmoAsset);
            var ammo = new CrossbowAmmo(view);
            var id = m_GameEntities.Add(ammo);
            view.EntityId = id;
            
            return ammo;
        }
    }
}