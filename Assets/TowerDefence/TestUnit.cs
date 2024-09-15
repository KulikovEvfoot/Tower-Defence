using System;
using TowerDefence.Core.Runtime.Entities;
using UnityEngine;
using Zenject;

namespace TowerDefence
{
    public class TestUnit : MonoBehaviour, IAliveGameObjectEntity
    {
        public event Action<IAliveGameObjectEntity, bool> OnAliveChanged;

        public int EntityId { get; set; }
        public GameObject GameObject => gameObject;
        
        public bool IsAlive()
        {
            return isActive;
        }
        
        
        //runtime test
        [Inject] private IGameEntities GameEntities;

        private bool isActive;
        private void Start()
        {
            var t = new TestEntity(gameObject);
            var id = GameEntities.Add(t);
            t.SetId(id);
            EntityId = id;
            
            isActive = true;
        }

        [ContextMenu("disable")]
        public void Dis()
        {
            isActive = !isActive;
            gameObject.SetActive(isActive);
            OnAliveChanged?.Invoke(this, isActive);
        }
    }
}