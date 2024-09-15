using System;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence
{
    public class TestUnit : MonoBehaviour, IAliveGameObjectEntity
    {
        public event Action<IAliveGameObjectEntity, bool> OnAliveChanged;

        public int EntityId { get; private set; }
        
        public GameObject GameObject => gameObject;

        public void SetId(int id)
        {
            EntityId = id;
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}