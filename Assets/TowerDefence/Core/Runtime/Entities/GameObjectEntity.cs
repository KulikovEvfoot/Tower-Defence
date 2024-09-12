using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class GameObjectEntity : MonoBehaviour, IGameObjectEntity
    {
        //its only to show. need readonly attribute
        [SerializeField] private int m_Id;
        
        public int Id { get; private set; }
        public GameObject GameObject => gameObject;

        public void Set(int id)
        {
            Id = id;
            m_Id = id;
        }
    }
}