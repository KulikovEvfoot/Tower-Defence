using System;
using TowerDefence.InputSystem.KeyboardAndMouse;
using UnityEngine;

namespace TowerDefence.InputSystem
{
    public class CoreInput : ICoreInput, IDisposable
    {
        public event Action<Vector2> MovingInputReceived;
        public event Action<bool> SwipeInputReceived;

        private readonly InputMap m_InputMap;
    
        private KeyboardAndMouseInput m_KeyboardAndMouseInput;

        public CoreInput()
        {
            m_InputMap = new InputMap();
        
            m_InputMap.Enable();

            InitKeyBoardInput(m_InputMap);
        }

        private void InitKeyBoardInput(InputMap inputMap)
        {
            m_KeyboardAndMouseInput = new KeyboardAndMouseInput(inputMap);
            m_KeyboardAndMouseInput.MovingInputReceived += OnMovingInputReceived;
            m_KeyboardAndMouseInput.SwipeInputReceived += OnSwipeInputReceived;
        }

        private void OnMovingInputReceived(Vector2 delta)
        {
            MovingInputReceived?.Invoke(delta);
        }
        
        private void OnSwipeInputReceived(bool isOn)
        {
            SwipeInputReceived?.Invoke(isOn);
        }

        public void Dispose()
        {
            if (m_KeyboardAndMouseInput != null)
            {
                m_KeyboardAndMouseInput.MovingInputReceived -= OnMovingInputReceived;
                m_KeyboardAndMouseInput.SwipeInputReceived -= OnSwipeInputReceived;
            }

            m_InputMap?.Dispose();
        }
    }
}