using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RifleAmmo : IAmmo
    {
        private readonly RifleAmmoView m_RifleAmmoView;
        private readonly Vector3 m_Position;

        public Vector3 Position
        {
            get => m_RifleAmmoView.Position;
            set => m_RifleAmmoView.Position = value;
        }

        public RifleAmmo(RifleAmmoView view)
        {
            m_RifleAmmoView = view;
        }

        public void SetActive(bool isActive)
        {
            m_RifleAmmoView.SetActive(isActive);
        }
    }
}