using TowerDefence.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime
{
    public class RifleTowerView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Root;
        [SerializeField] private RifleWeaponView m_RifleWeaponView;
        
        public RifleAmmoAnchorPoint AmmoAnchorPoint { get; private set; }

        public void Init()
        {
            AmmoAnchorPoint = new RifleAmmoAnchorPoint(m_RifleWeaponView);
        }
    }
}