using TowerDefence.Core.Runtime.Entities;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowAmmo : IGameEntity, IAmmo
    {
        private readonly CrossbowAmmoView m_View;

        public int EntityId { get; set; }
        public Transform Transform => m_View.Transform;
        
        internal CrossbowAmmo(CrossbowAmmoView view)
        {
            m_View = view;
        }

        public void SetActive(bool isActive)
        {
            m_View.SetActive(isActive);
        }

        public void SetParent(Transform anchorPointParent)
        {
            m_View.SetParent(anchorPointParent);
        }
    }
}