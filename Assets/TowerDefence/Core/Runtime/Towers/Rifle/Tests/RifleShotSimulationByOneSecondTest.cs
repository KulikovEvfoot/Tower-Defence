using NUnit.Framework;
using TowerDefence.Core.Runtime.Stub;
using TowerDefence.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Towers.Rifle.Tests
{
    public class RifleShotSimulationByOneSecondTest : MonoBehaviour
    {
        private const float m_Second = 1f;
    
        private Vector3 m_SenderPosition;
        private Vector3 m_TargetPosition;
        private StubShotTarget m_StubTarget;
        private StubAmmo m_StubAmmo;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_SenderPosition = Vector3.zero;
            m_TargetPosition = new Vector3(1, 0, 0);
        }

        [SetUp]
        public void SetUp()
        {
            m_StubTarget = new StubShotTarget { Position = m_TargetPosition };
            m_StubAmmo = new StubAmmo { Position = m_SenderPosition };
        }
    
        [Test]
        public void Should_HitTarget_Speed_1()
        {
            var ammoSpeed = 1;
            var simulation = new RifleShotSimulation(m_SenderPosition, m_StubTarget, m_StubAmmo, ammoSpeed);
            
            simulation.Move(m_Second);
        
            Assert.IsTrue(simulation.IsCompleted);
            Assert.AreEqual(simulation.Ammo.Position, m_TargetPosition);
        }
    
        [Test]
        public void Should_HitTarget_Speed_2()
        {
            var ammoSpeed = 2;
            var simulation = new RifleShotSimulation(m_SenderPosition, m_StubTarget, m_StubAmmo, ammoSpeed);
            
            simulation.Move(m_Second);
        
            Assert.IsTrue(simulation.IsCompleted);
            Assert.AreEqual(simulation.Ammo.Position, m_TargetPosition);
        }
    
        [Test]
        public void ShouldNot_HitTarget_Speed_05f()
        {
            var ammoSpeed = 0.5f;
            var simulation = new RifleShotSimulation(m_SenderPosition, m_StubTarget, m_StubAmmo, ammoSpeed);
        
            simulation.Move(m_Second);
        
            Assert.IsFalse(simulation.IsCompleted);
            Assert.AreNotEqual(simulation.Ammo.Position, m_TargetPosition);
        }
    }
}
