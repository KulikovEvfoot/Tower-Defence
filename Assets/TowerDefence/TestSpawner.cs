using System;
using Common;
using TowerDefence.Core.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence
{
    public class TestSpawner : MonoBehaviour
    {
        [SerializeField] private TestUnit m_TestUnit;
        
        [Inject] private IGameEntities m_GameEntities;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                var testEntity = new TestEntity();

                var id = m_GameEntities.Add(testEntity);
                
                testEntity.SetId(id);
                
                var unit = Instantiate(m_TestUnit, new Vector3(30, 0 ,0), Quaternion.identity);
                
                unit.SetId(id);
            }
        }
    }
    
    public class TestEntity : IGameEntity, IShotTarget
    {
        public int EntityId { get; private set; }
        public GameObject View { get; }
        public Vector3 Position => View.transform.position;

        public void SetId(int id)
        {
            EntityId = id;
        }

    }
}