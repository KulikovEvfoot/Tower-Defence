using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Logger;
using TowerDefence.Core.Runtime.Scene.Scene;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Scene
{
    public class LocationBalanceFacade : ILocationBalanceFacade
    {
        private readonly ILogger m_Logger;
        
        private SceneLocationSettings m_SceneLocationSettings;

        public LocationBalanceFacade()
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(LocationBalanceFacade)}]:");
        }

        //todo: когда добвлю сейвы сменить этот костыль на конструктор
        public void Setup(SceneLocationSettings sceneLocationSettings)
        {
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