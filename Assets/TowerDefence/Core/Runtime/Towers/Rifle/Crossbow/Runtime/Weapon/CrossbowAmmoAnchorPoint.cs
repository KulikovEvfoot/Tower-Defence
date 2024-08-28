using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class CrossbowAmmoAnchorPoint
    {
        private readonly CrossboweWeaponView m_CrossbowWeaponView;

        public CrossbowAmmoAnchorPoint(CrossboweWeaponView crossbowWeaponView)
        {
            m_CrossbowWeaponView = crossbowWeaponView;
        }

        public Transform Parent => m_CrossbowWeaponView.AmmoSpawnParent;
        public Vector3 Position => m_CrossbowWeaponView.Position;
        public Quaternion Rotation => m_CrossbowWeaponView.Rotation;
    }
}