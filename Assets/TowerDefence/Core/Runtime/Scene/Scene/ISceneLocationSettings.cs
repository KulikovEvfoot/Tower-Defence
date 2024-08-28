using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Towers.Config
{
    public interface ISceneLocationSettings
    {
        public IReadOnlyList<TowerWaypoint> TowerPoints { get; }
    }
}