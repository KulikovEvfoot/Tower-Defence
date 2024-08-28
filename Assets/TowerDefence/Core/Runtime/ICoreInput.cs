using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime
{
    public interface ICoreInput
    {
        public event Action<Vector2> CursorPositionInputReceived;
        public event Action TapInputReceived;
        event Action<Vector2> MovingInputReceived;
        event Action<bool> SwipeInputReceived;
    }
}