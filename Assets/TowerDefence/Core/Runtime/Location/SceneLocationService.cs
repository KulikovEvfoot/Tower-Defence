using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers;
using TowerDefence.Core.Runtime.Towers.Place.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;

namespace TowerDefence.Core.Runtime.Location
{
    public class SceneLocationService : ISceneLocationService
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;

        public SceneLocationService(ILocationBalanceFacade locationBalanceFacade, ITowerServices towerServices)
        {
            m_LocationBalanceFacade = locationBalanceFacade;
            var towerWaypoints = locationBalanceFacade.GetTowerWaypoints();
            foreach (var towerWaypoint in towerWaypoints)
            {
                var factoryResult = towerServices.GetFactory(RifleTowerEnvironment.Key);
                // var factoryResult = towerServices.GetFactory(TowerPlaceEnvironment.Key);
                if (!factoryResult.IsExist)
                {
                    continue;
                }

                var towerResult = factoryResult.Object.Create(towerWaypoint.PointId, new TowerLevel(RifleTowerEnvironment.CrossbowSubtype, 0));
                // var towerResult = factoryResult.Object.Create(towerWaypoint.PointId, TowerLevel.Empty);
            }
        }
    }

    public interface ISceneLocationService
    {
    }
}