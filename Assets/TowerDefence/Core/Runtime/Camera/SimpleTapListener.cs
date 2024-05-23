using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Camera
{
    public class SimpleTapListener : MonoBehaviour, ICoreTapListener
    {
        public event Action OnTapEvent;
        
        public void OnTap()
        {
            OnTapEvent?.Invoke();
        }
    }
}