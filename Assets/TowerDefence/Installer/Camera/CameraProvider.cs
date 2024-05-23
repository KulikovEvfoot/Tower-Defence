using UnityEngine;

namespace TowerDefence.Installer.Camera
{
    public class CameraProvider : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera m_MainCamera;
        [SerializeField] private Transform m_MainCameraTransform;
        
        [SerializeField] private UnityEngine.Camera m_GuiCamera;

        public UnityEngine.Camera MainCamera => m_MainCamera;
        public Transform MainCameraTransform => m_MainCameraTransform;
        
        public UnityEngine.Camera GuiCamera => m_GuiCamera;
    }
}