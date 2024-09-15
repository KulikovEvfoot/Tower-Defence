using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IGameObjectEntity
    {
        int EntityId { get; }
        GameObject GameObject { get; }
    }

    public interface IAliveGameObjectEntity : IGameObjectEntity
    {
        event Action<IAliveGameObjectEntity, bool> OnAliveChanged;

        bool IsAlive();
    }
}