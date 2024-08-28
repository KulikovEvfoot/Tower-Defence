using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Camera
{
    public class CameraSwipeMotion : IDisposable
    {
        private const float m_Sensitivity = 23f;
        
        private readonly ICoreInput m_CoreInput;
        private readonly Transform m_CameraTransform;
        
        private float m_Vertical;
        private float m_Horizontal;

        private bool m_IsSwipeStarted;
        
        public CameraSwipeMotion(ICoreInput coreInput, Transform cameraTransform)
        {
            m_CoreInput = coreInput;
            m_CameraTransform = cameraTransform;
            
            m_CoreInput.MovingInputReceived += OnMoveReceived;
            m_CoreInput.SwipeInputReceived += OnSwipeReceived;
        }
        
        private void OnMoveReceived(Vector2 delta)
        {
            if (!m_IsSwipeStarted)
            {
                return;
            }
            
            var dt = Time.deltaTime;
            m_Vertical -= m_Sensitivity * delta.x * dt;
            m_Horizontal -= m_Sensitivity * delta.y * dt;

            var y = m_CameraTransform.position.y;
            m_CameraTransform.position = new Vector3(m_Vertical, y, m_Horizontal);
        }

        private void OnSwipeReceived(bool isOn)
        {
            m_IsSwipeStarted = isOn;
            
            var position = m_CameraTransform.position;
            m_Vertical = position.x;
            m_Horizontal = position.z;
        }

        public void Dispose()
        {
            if (m_CoreInput != null)
            {
                m_CoreInput.MovingInputReceived -= OnMoveReceived;
                m_CoreInput.SwipeInputReceived -= OnSwipeReceived;
            }
        }
    }
}