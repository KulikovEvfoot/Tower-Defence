using System;
using TowerDefence.InputSystem;
using UnityEngine;
using Zenject;

namespace TowerDefence.Installer.Camera
{
    //test
    public class CameraMoveHandler : IDisposable
    {
        private ICoreInput m_CoreInput;
        private float m_Sensitivity = 5f;
        private float m_Vertical;
        private float m_Horizontal;

        private bool m_IsSwipeStarted;
        
        [Inject]
        public CameraMoveHandler(ICoreInput coreInput)
        {
            m_CoreInput = coreInput;

            m_CoreInput.MovingInputReceived += OnMoveReceived;
            m_CoreInput.SwipeInputReceived += OnSwipeReceived;
        }

        private void OnMoveReceived(Vector2 delta)
        {
            if (!m_IsSwipeStarted)
            {
                return;
            }
            
            var camera = UnityEngine.Camera.main;
            var transform = camera.GetComponent<Transform>();

            var dt = Time.deltaTime;
            m_Vertical -= m_Sensitivity * delta.x * dt;
            m_Horizontal -= m_Sensitivity * delta.y * dt;

            transform.position = new Vector3(m_Vertical, 10, m_Horizontal);
        }

        private void OnSwipeReceived(bool isOn)
        {
            m_IsSwipeStarted = isOn;
        }

        public void Dispose()
        {
            if (m_CoreInput != null)
            {
                m_CoreInput.MovingInputReceived -= OnMoveReceived;
                m_CoreInput.MovingInputReceived -= OnMoveReceived;
            }
        }
    }
}