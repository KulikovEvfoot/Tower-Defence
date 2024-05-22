using Common;
using TowerDefence.InputSystem;
using TowerDefence.Installer.Camera;
using TowerDefence.Installer.Launcher;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner m_CoroutineRunner;
        
        public override void InstallBindings()
        {
            Debug.Log("Core scene installer");
            
            Container.Bind<ICoreInput>().To<CoreInput>().AsSingle().NonLazy();
            
            Container.Bind<CameraMoveHandler>().AsSingle().NonLazy();
            
            Container.Bind<ICoroutineRunner>().FromInstance(m_CoroutineRunner).AsSingle().NonLazy();
            
            Container.Bind<IInitializable>().To<CoreSceneLauncher>().AsSingle().NonLazy();
        }
    }
}