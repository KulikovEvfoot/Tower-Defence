using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Logger;
using TowerDefence.Core.Runtime.Towers.Config;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Config
{
    public class LocationBalanceFacade : ILocationBalanceFacade
    {
        private readonly ILogger m_Logger;
        private readonly SceneLocationSettings m_SceneLocationSettings;

        public LocationBalanceFacade(SceneLocationSettings sceneLocationSettings)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(LocationBalanceFacade)}]:");
            
            m_SceneLocationSettings = sceneLocationSettings;
        }
        
        public Result<TowerWaypoint> GetTowerWaypoint(int pointId)
        {
            var towerWaypoint = m_SceneLocationSettings.TowerPoints.FirstOrDefault(p => p.PointId == pointId);
            return new Result<TowerWaypoint>(towerWaypoint, isExist: towerWaypoint != null);
        }

        public IEnumerable<TowerWaypoint> GetTowerWaypoints()
        {
            return m_SceneLocationSettings.TowerPoints;
        }
    }
}