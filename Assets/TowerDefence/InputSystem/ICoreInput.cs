using System;
using UnityEngine;

namespace TowerDefence.InputSystem
{
    public interface ICoreInput
    {
        event Action<Vector2> MovingInputReceived;
        public event Action<bool> SwipeInputReceived;
    }
}