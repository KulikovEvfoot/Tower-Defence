using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IGameObjectEntity
    {
        int Id { get; }
        GameObject GameObject { get; }
    }
}