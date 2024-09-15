using UnityEngine;

namespace TowerDefence.Core.Runtime.Entities
{
    public interface IGameObjectEntity
    {
        int EntityId { get; set; }
        GameObject GameObject { get; }
    }
}