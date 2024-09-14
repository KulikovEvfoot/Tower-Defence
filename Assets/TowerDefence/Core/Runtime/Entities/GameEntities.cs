using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class GameEntities : IGameEntities
    {
        private readonly Dictionary<int, IGameEntity> m_Entities = new();
        private readonly IIdFactory m_IdFactory;
        
        public IReadOnlyDictionary<int, IGameEntity> Entities => m_Entities;

        public GameEntities(IIdFactory idFactory)
        {
            m_IdFactory = idFactory;
        }

        public int Add(IGameEntity entity)
        {
            var id = m_IdFactory.CreateNext();
            m_Entities.TryAdd(id, entity);
            return id;
        }

        public int Add(IGameObjectEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            m_Entities.Remove(id);
        }

        public bool Contains(int id)
        {
            return m_Entities.ContainsKey(id);
        }

        public Result<IGameEntity> Get(int id)
        {
            if (m_Entities.TryGetValue(id, out var entity))
            {
                return Result<IGameEntity>.Success(entity);
            }

            return Result<IGameEntity>.Fail();
        }
    }
}