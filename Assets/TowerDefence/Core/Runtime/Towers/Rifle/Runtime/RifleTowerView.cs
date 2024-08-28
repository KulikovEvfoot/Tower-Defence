using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleTowerView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Root;
        [SerializeField] private RifleWeaponView m_RifleWeaponView;
        [SerializeField] private RifleAmmoView m_RifleAmmoTemplate;

        public RifleAmmoAnchorPoint AmmoAnchorPoint { get; private set; }
        public RifleAmmoView RifleAmmoTemplate => m_RifleAmmoTemplate;
        
        public void Init()
        {
            AmmoAnchorPoint = new RifleAmmoAnchorPoint(m_RifleWeaponView);
        }
    }
}