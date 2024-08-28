using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Root;
        [SerializeField] private CrossboweWeaponView m_CrossbowWeaponView;
        [SerializeField] private CrossbowAmmoView m_CrossbowAmmoTemplate;

        public CrossbowAmmoAnchorPoint AmmoAnchorPoint { get; private set; }
        public CrossbowAmmoView CrossbowAmmoTemplate => m_CrossbowAmmoTemplate;
        
        public void Init()
        {
            AmmoAnchorPoint = new CrossbowAmmoAnchorPoint(m_CrossbowWeaponView);
        }
    }
}