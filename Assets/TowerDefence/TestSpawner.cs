using System;
using Common;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence
{
    public class TestSpawner : MonoBehaviour
    {
        [SerializeField] private TestUnit m_TestUnit;
        
        [Inject] private IGameEntities m_GameEntities;
        
        private IdFactory m_Factory;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                var id = m_Factory.CreateNext();
                
                var unit = Instantiate(m_TestUnit, Vector3.zero, Quaternion.identity);
                unit.SetId(id);
                
                var t = new TestEntity(id);
                
                m_GameEntities.Add(id, t);
            }
        }
    }
    
    public class TestEntity : IGameEntity
    {
        public int Id { get; }

        public TestEntity(int id)
        {
            Id = id;
        }
    }
}