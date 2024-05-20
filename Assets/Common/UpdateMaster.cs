using System;
using UnityEngine;

namespace Common
{
    public class UpdateMaster : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action OnLateUpdate;
        
        private void Update()
        {
            OnUpdate?.Invoke();
        }
        
        private void LateUpdate()
        {
            OnLateUpdate?.Invoke();
        }
    }
}