using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class CrossbowAmmo : IAmmo
    {
        private readonly CrossbowAmmoView m_View;

        public Vector3 Position
        {
            get => m_View.Position;
            set => m_View.Position = value;
        }
        
        public Quaternion Rotation
        {
            get => m_View.Rotation;
            set => m_View.Rotation = value;
        }

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