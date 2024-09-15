using Common;
using NUnit.Framework;

namespace TowerDefence.Core.Runtime.Entities.Tests
{
    public class GameEntitiesTest
    {
        private IGameEntities m_GameEntities;

        [SetUp]
        public void SetUp()
        {
            var idFactory = new IdFactory();
            m_GameEntities = new GameEntities(idFactory);
        }
    
        [Test]
        public void Should_Added_3_Entity()
        {
            var mockEntity1 = new MockEntity();
            var mockEntity2 = new MockEntity();
            var mockEntity3 = new MockEntity();
        
            var id1 = m_GameEntities.Add(mockEntity1);
            var id2 = m_GameEntities.Add(mockEntity2);
            var id3 = m_GameEntities.Add(mockEntity3);

            var result1 = m_GameEntities.Get(id1);
            var result2 = m_GameEntities.Get(id2);
            var result3 = m_GameEntities.Get(id3);
        
            Assert.IsTrue(result1.IsExist);
            Assert.IsTrue(result2.IsExist);
            Assert.IsTrue(result3.IsExist);
        
            Assert.AreEqual(result1.Object, mockEntity1);
            Assert.AreEqual(result2.Object, mockEntity2);
            Assert.AreEqual(result3.Object, mockEntity3);
        }
    
        [Test]
        public void Should_Contains_Entity()
        {
            var mockEntity1 = new MockEntity();
        
            var id1 = m_GameEntities.Add(mockEntity1);

            var result1 = m_GameEntities.Get(id1);
        
            Assert.IsTrue(result1.IsExist);
            Assert.AreEqual(result1.Object, mockEntity1);
            Assert.IsTrue(m_GameEntities.Contains(id1));
        }
    
        [Test]
        public void Should_Remove_Entity()
        {
            var mockEntity1 = new MockEntity();
        
            var id1 = m_GameEntities.Add(mockEntity1);

            var result1 = m_GameEntities.Get(id1);
        
            Assert.IsTrue(result1.IsExist);
            Assert.AreEqual(result1.Object, mockEntity1);
        
            m_GameEntities.Remove(id1);
        
            Assert.IsFalse(m_GameEntities.Contains(id1));
        }
    
        [Test]
        public void Should_Entity_Collection_Update()
        {
            var mockEntity1 = new MockEntity();
            m_GameEntities.Add(mockEntity1);
            var countAfterFirstAdd = m_GameEntities.Entities.Count;
            Assert.AreEqual(countAfterFirstAdd, 1);
        
            var mockEntity2 = new MockEntity();
            var id2= m_GameEntities.Add(mockEntity2);
            var countAfterSecondAdd = m_GameEntities.Entities.Count;
            Assert.AreEqual(countAfterSecondAdd, 2);

            m_GameEntities.Remove(id2);
            var countAfterRemove = m_GameEntities.Entities.Count;
            Assert.AreEqual(countAfterRemove, 1);
        }
    }
}
