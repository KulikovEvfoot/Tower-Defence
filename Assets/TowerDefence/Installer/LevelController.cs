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
        private LocationBalanceFacade m_LocationBalanceFacade;
        
        public ILocationBalanceFacade LocationBalanceFacade => m_LocationBalanceFacade;

        [Inject]
        public LevelController(AddressablesService addressablesService)
        {
            m_AddressableService = addressablesService;
        }

        public LoadingResult LoadResources()
        {
            var sceneConfigGo = m_AddressableService.LoadSync<GameObject>(m_SceneLocationSettings_1);
            var sceneConfig = sceneConfigGo.GetComponent<SceneLocationSettings>();
            
            m_LocationBalanceFacade = new LocationBalanceFacade(sceneConfig);
            
            return LoadingResult.Sync;
        }

        public void Launch()
        {

        }
    }
}