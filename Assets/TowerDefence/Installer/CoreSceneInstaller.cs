using UnityEngine;
using Zenject;

namespace TowerDefence.Installer
{
    public class CoreSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Debug.Log("Core scene installer");
        }
    }
}