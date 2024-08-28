using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Camera
{
    public class CoreTapProcessor : IDisposable
    {
        private const float m_RayMaxDistance = 1000f;
        
        private readonly RaycastHit[] m_RaycastResults = new RaycastHit[1];
        
        private readonly ICoreInput m_CoreInput;
        private readonly UnityEngine.Camera m_Camera;
        
        private readonly int m_CheckLayerIndex;
        
        private Vector2 m_MousePosition;

        public CoreTapProcessor(ICoreInput coreInput, UnityEngine.Camera camera)
        {
            m_CoreInput = coreInput;
            m_Camera = camera;
            
            m_CheckLayerIndex = LayerMask.GetMask(LayerEnvironment.Tapable);
            
            m_CoreInput.CursorPositionInputReceived += OnCursorReceived;
            m_CoreInput.TapInputReceived += OnTapReceived;
        }

        private void OnCursorReceived(Vector2 mousePosition)
        {
            m_MousePosition = mousePosition;
        }

        private void OnTapReceived()
        {
            var ray = m_Camera.ScreenPointToRay(m_MousePosition);
            var hitsCount = Physics.RaycastNonAlloc(
                ray,
                m_RaycastResults,
                maxDistance: m_RayMaxDistance,
                layerMask: m_CheckLayerIndex);
            
            for (int i = 0; i < hitsCount; i++)
            {
                var item = m_RaycastResults[i];
                if (!item.transform.TryGetComponent<ICoreTapListener>(out var tapListener))
                {
                    continue;
                }

                tapListener.OnTap();
                break;
            }
        }

        public void Dispose()
        {
            if (m_CoreInput != null)
            {
                m_CoreInput.CursorPositionInputReceived += OnCursorReceived;
                m_CoreInput.TapInputReceived += OnTapReceived;  
            } 
        }
    }
}