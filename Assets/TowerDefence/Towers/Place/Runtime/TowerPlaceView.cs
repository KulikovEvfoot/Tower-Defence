using TowerDefence.Core.Runtime.Camera;
using TowerDefence.Core.Runtime.Command.CreateTower;
using UnityEngine;

namespace TowerDefence.Towers.Place.Runtime
{
    public class TowerPlaceView : MonoBehaviour
    {
        [SerializeField] private SimpleTapListener m_SimpleTapListener;
        [SerializeField] private CreateTowerViewController m_CreateTowerViewController;

        private void Awake()
        {
            m_SimpleTapListener.OnTapEvent += OnPlaceTap;
        }

        private void OnPlaceTap()
        {
            m_CreateTowerViewController.Show();
            //TODO: show ui
        }
    }
}