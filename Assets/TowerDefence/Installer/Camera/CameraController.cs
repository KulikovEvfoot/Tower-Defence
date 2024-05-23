using TowerDefence.Core.Runtime;
using TowerDefence.Core.Runtime.Camera;
using Zenject;

namespace TowerDefence.Installer.Camera
{
    public class CameraController
    {
        private readonly CoreTapProcessor m_CoreTapProcessor;
        private readonly CameraSwipeMotion m_CameraSwipeMotion;
        
        [Inject]
        public CameraController(ICoreInput coreInput, CameraProvider cameraProvider)
        {
            m_CameraSwipeMotion = new CameraSwipeMotion(coreInput, cameraProvider.MainCameraTransform);
            m_CoreTapProcessor = new CoreTapProcessor(coreInput, cameraProvider.MainCamera);
        }
    }
}