using System.Collections.Generic;
using Common;
using TowerDefence.Core.Runtime.Scene.Scene;

namespace TowerDefence.Core.Runtime.Scene
{
    public interface ILocationBalanceFacade
    {
        Result<TowerWaypoint> GetTowerWaypoint(int pointId);
        IEnumerable<TowerWaypoint> GetTowerWaypoints();
    }
}