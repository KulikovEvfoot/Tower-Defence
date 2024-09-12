using Launcher;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Config;
using TowerDefence.Installer.Stage;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    [global::Launcher.Stage(typeof(ConfigsLoadingStage), 0)]
    public class LevelController : IControlEntity
    {
        private const string m_SceneLocationSettings_1 = "SceneLocationSettings_1";
        
        private readonly AddressablesService m_AddressableService;
        private readonly LocationBalanceFacade m_LocationBalanceFacade;
        
        public ILocationBalanceFacade LocationBalanceFacade => m_LocationBalanceFacade;

        [Inject]
        public LevelController(AddressablesService addressablesService, LocationBalanceFacade locationBalanceFacade)
        {
            m_AddressableService = addressablesService;
            m_LocationBalanceFacade = locationBalanceFacade;
        }

        public LoadingResult LoadResources()
        {
            var sceneConfigGo = m_AddressableService.LoadSync<GameObject>(m_SceneLocationSettings_1);
            var sceneConfig = sceneConfigGo.GetComponent<SceneLocationSettings>();
            
            m_LocationBalanceFacade.Setup(sceneConfig);
            
            return LoadingResult.Sync;
        }

        public void Launch()
        {

        }
    }
}