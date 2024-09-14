using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IGameObjectEntity
    {
        int EntityId { get; }
        GameObject GameObject { get; }
    }
}