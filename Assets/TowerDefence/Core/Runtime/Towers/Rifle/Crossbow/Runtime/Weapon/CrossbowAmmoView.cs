using TowerDefence.Core.Runtime.Entities;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowAmmoView : MonoBehaviour, IGameObjectEntity
    {
        [SerializeField] private GameObject m_Root;

        public int EntityId { get; set; }
        public GameObject GameObject => m_Root;
        public Transform Transform => m_Root.transform;

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