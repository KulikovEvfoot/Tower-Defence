using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using Launcher;
using TowerDefence.Core.Runtime.AddressablesSystem;
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
        private readonly AddressablesService m_AddressablesService;
        private readonly LevelController m_LevelController;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly List<ITowerService> m_TowerServices;
        
        private readonly ILogger m_Logger;
        
        private TowersServices m_TowersServices;

        public ITowerServices TowerServices => m_TowersServices;
        
        [Inject]
        public TowersController(
            AddressablesService addressablesService,
            LevelController levelController,
            List<ITowerService> towerServices)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(TowersController)}]: ");
            m_AddressablesService = addressablesService;
            m_LevelController = levelController;
            m_TowerServices = towerServices;
        }

        public LoadingResult LoadResources()
        {
            var towersMap = m_TowerServices.ToDictionary(k => k.Key);
            m_TowersServices = new TowersServices(m_LevelController.LocationBalanceFacade, towersMap);

            var task = m_TowersServices.Preload();
            return new LoadingResult(true, () => task.Status == UniTaskStatus.Succeeded);
        }

        public void Launch()
        {
            m_TowersServices.Init();
        }
    }
}