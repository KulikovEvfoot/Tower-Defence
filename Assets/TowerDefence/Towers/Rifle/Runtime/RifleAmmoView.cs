using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RifleAmmoView : MonoBehaviour
    {
        [SerializeField] private GameObject m_Root;

        public Vector3 Position
        {
            get => m_Root.transform.position;
            set => m_Root.transform.position = value;
        }
    
        public void SetActive(bool isActive)
        {
            m_Root.SetActive(isActive);
        }
    }
}