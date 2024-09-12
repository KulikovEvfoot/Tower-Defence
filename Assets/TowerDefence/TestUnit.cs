using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence
{
    public class TestUnit : MonoBehaviour, IGameObjectEntity
    {
        public int Id { get; private set; }
        
        public GameObject GameObject => gameObject;

        public void SetId(int id)
        {
            Id = id;
        }
    }
}