using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IGameEntities
    {
        IReadOnlyDictionary<int, IGameEntity> Entities { get; }
        
        int Add(IGameEntity entity);
        Result<IGameEntity> Get(int id);
    }
}