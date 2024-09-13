using Services.Timer.Runtime;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            Debug.Log("Global installer");
            
            Container.Bind<IGlobalTimer>().To<GlobalTimer>().AsSingle().NonLazy();
        }
    }
}