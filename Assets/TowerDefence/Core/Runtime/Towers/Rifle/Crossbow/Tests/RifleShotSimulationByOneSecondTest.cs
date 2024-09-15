using NUnit.Framework;
using TowerDefence.Core.Runtime.Mock;
using TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Tests
{
    public class RifleShotSimulationByOneSecondTest : MonoBehaviour
    {
        private const float m_Second = 1f;
    
        private Vector3 m_SenderPosition;
        private Vector3 m_TargetPosition;
        private MockShotTarget m_MockTarget;
        private MockAmmo m_MockAmmo;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            m_SenderPosition = Vector3.zero;
            m_TargetPosition = new Vector3(1, 0, 0);
        }

        [SetUp]
        public void SetUp()
        {
            m_MockTarget = new MockShotTarget { Position = m_TargetPosition };
            var testGo = new GameObject();
            m_MockAmmo = new MockAmmo(testGo.transform);
        }
    
        [Test]
        public void Should_HitTarget_Speed_1()
        {
            var ammoSpeed = 1;
            var simulation = new CrossbowShotSimulation(m_MockTarget, m_MockAmmo, ammoSpeed);
            
            simulation.Move(m_Second);
        
            Assert.IsTrue(simulation.IsCompleted);
            Assert.AreEqual(simulation.Ammo.Transform.position, m_TargetPosition);
        }
    
        [Test]
        public void Should_HitTarget_Speed_2()
        {
            var ammoSpeed = 2;
            var simulation = new CrossbowShotSimulation(m_MockTarget, m_MockAmmo, ammoSpeed);
            
            simulation.Move(m_Second);
        
            Assert.IsTrue(simulation.IsCompleted);
            Assert.AreEqual(simulation.Ammo.Transform.position, m_TargetPosition);
        }
    
        [Test]
        public void ShouldNot_HitTarget_Speed_05f()
        {
            var ammoSpeed = 0.5f;
            var simulation = new CrossbowShotSimulation(m_MockTarget, m_MockAmmo, ammoSpeed);
        
            simulation.Move(m_Second);
        
            Assert.IsFalse(simulation.IsCompleted);
            Assert.AreNotEqual(simulation.Ammo.Transform.position, m_TargetPosition);
        }
    }
}
