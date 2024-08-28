using System;
using UnityEngine;

namespace TowerDefence.InputSystem.KeyboardAndMouse
{
    public class KeyboardAndMouseInput
    {
        public event Action<Vector2> CursorPositionInputReceived;
        public event Action TapInputReceived;
        public event Action<Vector2> MovingInputReceived;
        public event Action<bool> SwipeInputReceived;
        
        //TODO: это чисто потестить, подумать как сделать нормальный детект
        public KeyboardAndMouseInput(InputMap inputMap)
        {
            inputMap.KeyboardAndMouse.MousePosition.performed += context =>
            {
                var mouseDelta = context.ReadValue<Vector2>();
                CursorPositionInputReceived?.Invoke(mouseDelta);
            };
            
            inputMap.KeyboardAndMouse.MouseTap.performed += context =>
            {
                TapInputReceived?.Invoke();
            };
            
            inputMap.KeyboardAndMouse.MouseDelta.performed += context =>
            {
                var mouseDelta = context.ReadValue<Vector2>();
                MovingInputReceived?.Invoke(mouseDelta);
            };
            
            inputMap.KeyboardAndMouse.MouseSwipe.performed += context =>
            {
                var value = context.ReadValue<float>();
                var isOn = value == 1;
                
                SwipeInputReceived?.Invoke(isOn);
            };
        }
    }
}