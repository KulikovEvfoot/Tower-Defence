using System;
using TowerDefence.Core.Runtime.Camera;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Place.Runtime
{
    public class TowerPlaceView : MonoBehaviour
    {
        public event Action OnClick;
        
        [SerializeField] private SimpleTapListener m_SimpleTapListener;

        private void Awake()
        {
            m_SimpleTapListener.OnTapEvent += OnPlaceTap;
        }

        private void OnPlaceTap()
        {
            OnClick?.Invoke();
        }

        private void OnDestroy()
        {
            m_SimpleTapListener.OnTapEvent -= OnPlaceTap;
        }
    }
}