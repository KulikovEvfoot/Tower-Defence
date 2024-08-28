using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Launcher;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Config.External;
using TowerDefence.Core.Runtime.Towers;
using TowerDefence.Core.Runtime.Towers.Config;
using TowerDefence.Installer.Stage;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    [global::Launcher.Stage(typeof(ConfigsLoadingStage), 0)]
    public class LevelController : IControlEntity
    {
        private const string m_SceneConfigTestAddress = "SceneLocationConfig";
        private const string m_TowerPlaceConfigAddress = "TowerPlaceConfig";
        private const string m_RifleTowerConfigAddress = "RifleTowerConfig";
        
        private readonly AddressablesService m_AddressableService;
        private LocationBalanceFacade m_LocationBalanceFacade;
        
        public ILocationBalanceFacade LocationBalanceFacade => m_LocationBalanceFacade;

        [Inject]
        public LevelController(AddressablesController addressablesController)
        {
            m_AddressableService = addressablesController.AddressablesService;
        }

        public LoadingResult LoadResources()
        {
            var sceneConfig = m_AddressableService.LoadSync<SceneLocationConfig>(m_SceneConfigTestAddress);
            var externalLocationConfig = new ExternalLocationConfig();
            var externalTowerConfig = new ExternalTowersConfig(
                new Dictionary<string, string> 
                {
                    {TowersEnvironment.TowerPlace, m_TowerPlaceConfigAddress},
                    {TowersEnvironment.RifleTower, m_RifleTowerConfigAddress}
                });
            
            m_LocationBalanceFacade = new LocationBalanceFacade(m_AddressableService, sceneConfig, externalLocationConfig, externalTowerConfig);
            
            var task = m_LocationBalanceFacade.Preload();
            return new LoadingResult(true, () => task.Status == UniTaskStatus.Succeeded);
        }

        public void Launch()
        {

        }
    }
}