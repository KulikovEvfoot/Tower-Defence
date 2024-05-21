using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Root;

        public Vector3 Position
        {
            get => m_Root.transform.position;
            set => m_Root.transform.position = value;
        }

        public Quaternion Rotation     
        {
            get => m_Root.transform.rotation;
            set => m_Root.transform.rotation = value;
        }

        public void SetParent(Transform parent)
        {
            m_Root.transform.SetParent(parent);
        }

        public void SetActive(bool isActive)
        {
            m_Root.SetActive(isActive);
        }
    }
}