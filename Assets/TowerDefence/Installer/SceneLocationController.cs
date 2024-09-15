using Launcher;
using TowerDefence.Core.Runtime.Location;
using TowerDefence.Installer.Launcher.Stage;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    // ~ Game start
    [global::Launcher.Stage(typeof(ServicesInitStage), 10_000)]
    public class SceneLocationController : IControlEntity
    {
        private readonly LevelController m_LevelController;
        private readonly TowersController m_TowersController;
        
        private SceneLocationService m_SceneLocationService;
        
        [Inject]
        public SceneLocationController(LevelController levelController, TowersController towersController)
        {
            m_LevelController = levelController;
            m_TowersController = towersController;
        }

        public LoadingResult LoadResources()
        {
            return LoadingResult.Sync;
        }

        public void Launch()
        {
            m_SceneLocationService = new SceneLocationService(m_LevelController.LocationBalanceFacade, m_TowersController.TowerServices);
        }
    }
}