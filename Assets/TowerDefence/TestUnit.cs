using System;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;
using Zenject;

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
            SetId(id);
            
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