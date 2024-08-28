using System.Collections.Generic;
using Common;
using TowerDefence.Core.Runtime.Towers.Config;

namespace TowerDefence.Core.Runtime.Config
{
    public interface ILocationBalanceFacade
    {
        Result<TowerWaypoint> GetTowerWaypoint(int pointId);
        IEnumerable<int> GetLevelPreset();//TODO: переделать
        
        Result<T> GetTowerSetting<T>(string name) where T : class;
        IEnumerable<string> GetAvailableTowers();
    }
}