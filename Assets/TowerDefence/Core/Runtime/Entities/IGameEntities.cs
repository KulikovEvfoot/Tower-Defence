using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Entities
{
    public interface IGameEntities
    {
        IReadOnlyDictionary<int, IGameEntity> Entities { get; }
        
        int Add(IGameEntity entity);
        Result<IGameEntity> Get(int id);
        void Remove(int id);
        bool Contains(int id);
    }
}