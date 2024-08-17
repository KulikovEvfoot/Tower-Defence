using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoAnchorPoint
    {
        private readonly RifleWeaponView m_RifleWeaponView;

        public RifleAmmoAnchorPoint(RifleWeaponView rifleWeaponView)
        {
            m_RifleWeaponView = rifleWeaponView;
        }

        public Transform Parent => m_RifleWeaponView.AmmoSpawnParent;
        public Vector3 Position => m_RifleWeaponView.Position;
        public Quaternion Rotation => m_RifleWeaponView.Rotation;
    }
}