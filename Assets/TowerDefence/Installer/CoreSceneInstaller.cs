using Common;
using Launcher;
using TowerDefence.Core.Runtime;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Place.Runtime;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using TowerDefence.InputSystem;
using TowerDefence.Installer.Camera;
using TowerDefence.Installer.Launcher;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] private CameraProvider m_CameraProvider;
        [SerializeField] private UpdateMaster m_UpdateMaster;
        
        public override void InstallBindings()
        {
            Debug.Log("Core scene installer");
            
            Container.Bind<ICoreInput>().To<CoreInput>().AsSingle().NonLazy();
            
            Container.Bind<CameraProvider>().FromInstance(m_CameraProvider).AsSingle().NonLazy();
            Container.Bind<CameraController>().AsSingle().NonLazy();
            
            Container.Bind<AddressablesService>().AsSingle().NonLazy();
            Container.Bind<UpdateMaster>().FromInstance(m_UpdateMaster).AsSingle().NonLazy();
            
            Container.Bind<IIdFactory>().To<IdFactory>().AsSingle().NonLazy();
            Container.Bind<IGameEntities>().To<GameEntities>().AsSingle().NonLazy();
            
            Container.Bind<LevelController>().AsSingle().NonLazy();
            Container.Bind<IControlEntity>().To<LevelController>().FromResolve().NonLazy();

            Container.Bind<LocationBalanceFacade>().AsSingle().NonLazy();
            Container.Bind<ILocationBalanceFacade>().To<LocationBalanceFacade>().FromResolve().NonLazy();
            
            Container.Bind<SceneLocationController>().AsSingle().NonLazy();
            Container.Bind<IControlEntity>().To<SceneLocationController>().FromResolve().NonLazy();
            
            BindTowers();
            
            Container.Bind<IInitializable>().To<CoreSceneLauncher>().AsSingle().NonLazy();
        }
        
        private void BindTowers()
        {
            Container.Bind<ITowerService>().To<TowerPlaceService>().AsSingle().NonLazy();
            Container.Bind<ITowerService>().To<RifleTowerService>().AsSingle().NonLazy();
            
            Container.Bind<TowersController>().AsSingle().NonLazy();
            Container.Bind<IControlEntity>().To<TowersController>().FromResolve().NonLazy();
        }

        
        [SerializeField] private TestSpawner m_TestSpawner;
        private void Test()
        {
            Container.Bind<TestSpawner>().FromInstance(m_TestSpawner).AsSingle().NonLazy();
        }
    }
}