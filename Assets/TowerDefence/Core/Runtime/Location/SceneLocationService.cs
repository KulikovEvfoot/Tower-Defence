using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers;

namespace TowerDefence.Core.Runtime.Location
{
    //создать точки
    public class SceneLocationService : ISceneLocationService
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;

        public SceneLocationService(ILocationBalanceFacade locationBalanceFacade, ITowerServices towerServices)
        {
            m_LocationBalanceFacade = locationBalanceFacade;
            var preset = locationBalanceFacade.GetLevelPreset();
            foreach (var pointId in preset)
            {
                var factoryResult = towerServices.GetFactory(TowersEnvironment.TowerPlace);
                if (!factoryResult.IsExist)
                {
                    continue;
                }

                var towerResult = factoryResult.Object.Create(pointId);
            }
        }
    }

    public interface ISceneLocationService
    {
    }
}