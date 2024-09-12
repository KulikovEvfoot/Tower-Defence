using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class GameEntities : IGameEntities
    {
        private readonly Dictionary<int, IGameEntity> m_Entities = new();

        public IReadOnlyDictionary<int, IGameEntity> Entities => m_Entities;
        
        public void Add(int id, IGameEntity entity)
        {
            m_Entities.TryAdd(id, entity);
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