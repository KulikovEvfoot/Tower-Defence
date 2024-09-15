using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Scene.Scene
{
    public interface ISceneLocationSettings
    {
        public IReadOnlyList<TowerWaypoint> TowerPoints { get; }
    }
}