using Common;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Place.Runtime
{
    public class TowerPlaceFactory : ITowerFactory
    {
        private readonly GameObject m_TowerPlaceViewAsset;
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;

        public TowerPlaceFactory(GameObject towerPlaceViewAsset, ILocationBalanceFacade locationBalanceFacade)
        {
            m_TowerPlaceViewAsset = towerPlaceViewAsset;
            m_LocationBalanceFacade = locationBalanceFacade;
        }

        public Result<ITower> Create(int pointId, TowerLevel towerLevel)
        {
            var towerWaypointResult = m_LocationBalanceFacade.GetTowerWaypoint(pointId);
            if (!towerWaypointResult.IsExist)
            {
                return Result<ITower>.Fail();
            }
            
            var go = Object.Instantiate(m_TowerPlaceViewAsset, towerWaypointResult.Object.Position, Quaternion.identity);

            if (!go.TryGetComponent<TowerPlaceView>(out var view))
            {
                return Result<ITower>.Fail();
            }
            
            var t = new TowerPlace();
            return Result<ITower>.Success(t);
        }
    }
}