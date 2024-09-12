using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerView : MonoBehaviour, ITowerView
    {
        [SerializeField] private GameObject m_Root;
        [SerializeField] private CrossboweWeaponView m_CrossbowWeaponView;
        [SerializeField] private CrossbowAmmoView m_CrossbowAmmoTemplate;
        [SerializeField] private SimpleInteractionObject m_InteractionObject;
        
        public CrossbowAmmoAnchorPoint AmmoAnchorPoint { get; private set; }
        public CrossbowAmmoView CrossbowAmmoTemplate => m_CrossbowAmmoTemplate;
        public IInteractionObject InteractionObject => m_InteractionObject;
        
        public void Init()
        {
            AmmoAnchorPoint = new CrossbowAmmoAnchorPoint(m_CrossbowWeaponView);
        }

        public void Spawn()
        {
            //TODO: add animation
        }

        public void Despawn()
        {
            //TODO: add animation
        }
    }
}