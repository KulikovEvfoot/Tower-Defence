using System;

namespace TowerDefence.Core.Runtime.Entities
{
    public interface IAliveGameObjectEntity : IGameObjectEntity
    {
        event Action<IAliveGameObjectEntity, bool> OnAliveChanged;

        bool IsAlive();
    }
}