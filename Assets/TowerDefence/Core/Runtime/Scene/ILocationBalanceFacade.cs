using System.Collections.Generic;
using Common;
using TowerDefence.Core.Runtime.Towers.Config;

namespace TowerDefence.Core.Runtime.Config
{
    public interface ILocationBalanceFacade
    {
        Result<TowerWaypoint> GetTowerWaypoint(int pointId);
        IEnumerable<TowerWaypoint> GetTowerWaypoints();
    }
}