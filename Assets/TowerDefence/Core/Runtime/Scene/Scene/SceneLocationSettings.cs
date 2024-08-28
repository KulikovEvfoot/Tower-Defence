using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Config
{
    public class SceneLocationSettings : MonoBehaviour, ISceneLocationSettings
    {
        [SerializeField] private List<TowerWaypoint> m_TowerPoints;

        public IReadOnlyList<TowerWaypoint> TowerPoints => m_TowerPoints;
    }
}