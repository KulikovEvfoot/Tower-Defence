using Common;
using TowerDefence.Core.Runtime;
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
        [SerializeField] private CoroutineRunner m_CoroutineRunner;
        
        public override void InstallBindings()
        {
            Debug.Log("Core scene installer");
            
            Container.Bind<ICoreInput>().To<CoreInput>().AsSingle().NonLazy();
            
            Container.Bind<CameraProvider>().FromInstance(m_CameraProvider).AsSingle().NonLazy();
            Container.Bind<CameraController>().AsSingle().NonLazy();
            
            Container.Bind<TowerFactoryProvider>().AsSingle().NonLazy();
            
            Container.Bind<AddressablesController>().AsSingle().NonLazy();
            
            Container.Bind<ICoroutineRunner>().FromInstance(m_CoroutineRunner).AsSingle().NonLazy();
            
            Container.Bind<IInitializable>().To<CoreSceneLauncher>().AsSingle().NonLazy();
        }
    }
}