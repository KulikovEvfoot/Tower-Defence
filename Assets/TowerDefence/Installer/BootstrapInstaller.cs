using Common;
using Common.Timer.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
    {
        [SerializeField] private CoroutineRunner m_CoroutineRunner;

        public override void InstallBindings()
        {
            Debug.Log("Global installer");
            
            Container.Bind<ICoroutineRunner>().FromInstance(m_CoroutineRunner).AsSingle().NonLazy();
            Container.Bind<IGlobalTimer>().To<GlobalTimer>().AsSingle().NonLazy();
        }
    }
}