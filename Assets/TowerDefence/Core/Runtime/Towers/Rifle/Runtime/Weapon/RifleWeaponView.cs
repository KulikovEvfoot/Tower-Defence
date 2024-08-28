using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class RifleWeaponView : MonoBehaviour
    {
        [SerializeField] private Transform m_AmmoSpawnParent;
        [SerializeField] private Transform m_Weapon;

        public Transform AmmoSpawnParent => m_AmmoSpawnParent;

        public Vector3 Position
        {
            get => m_Weapon.position;
            set => m_Weapon.position = value;
        }
        
        public Quaternion Rotation
        {
            get => m_Weapon.rotation;
            set => m_Weapon.rotation = value;
        }
    }
}