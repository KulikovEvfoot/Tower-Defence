using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence
{
    public class TestUnit : MonoBehaviour, IGameObjectEntity
    {
        public int EntityId { get; private set; }
        
        public GameObject GameObject => gameObject;

        public void SetId(int id)
        {
            EntityId = id;
        }
    }
}