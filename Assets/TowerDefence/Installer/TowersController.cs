using System.Collections.Generic;
using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using Launcher;
using TowerDefence.Core.Runtime.Towers;
using TowerDefence.Core.Runtime.Towers.Place.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using TowerDefence.Installer.Stage;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    [global::Launcher.Stage(typeof(ServicesInitStage), 100)]
    public class TowersController : IControlEntity
    {
        private readonly AddressablesController m_AddressablesController;
        private readonly LevelController m_LevelController;
        private readonly UpdateMaster m_UpdateMaster;
        
        private readonly ILogger m_Logger;
        
        private TowersServices m_TowersServices;

        public ITowerServices TowerServices => m_TowersServices;
        
        [Inject]
        public TowersController(
            AddressablesController addressablesController,
            LevelController levelController,
            UpdateMaster updateMaster)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(TowersController)}]: ");
            m_AddressablesController = addressablesController;
            m_LevelController = levelController;
            m_UpdateMaster = updateMaster;
        }

        public LoadingResult LoadResources()
        {
            var towerPreloader = new TowerPreloader(
                m_LevelController.LocationBalanceFacade,
                m_AddressablesController.AddressablesService,
                m_Logger);

            var towerPlaceService = new TowerPlaceService();
            
            var rifleTowerService = new RifleTowerService(
                m_LevelController.LocationBalanceFacade,
                towerPreloader,
                m_UpdateMaster);
            
            var towers = new Dictionary<string, ITowerService>();
            
            towers.Add(TowersEnvironment.TowerPlace, towerPlaceService);
            towers.Add(TowersEnvironment.RifleTower, rifleTowerService);
            
            m_TowersServices = new TowersServices(m_LevelController.LocationBalanceFacade, towers);

            var task = m_TowersServices.Preload();
            return new LoadingResult(true, () => task.Status == UniTaskStatus.Succeeded);
        }

        public void Launch()
        {
            m_TowersServices.Init();
        }
    }
}