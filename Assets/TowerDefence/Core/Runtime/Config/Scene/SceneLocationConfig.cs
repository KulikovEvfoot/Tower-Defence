using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Config
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SceneLocationConfig", fileName = "SceneLocationConfig", order = 0)]
    public class SceneLocationConfig : ScriptableObject
    {
        [SerializeField] private string m_LevelName;
        [SerializeField] private List<TowerWaypoint> m_TowerPoints;

        public string LevelName => m_LevelName;
        public IReadOnlyList<TowerWaypoint> TowerPoints => m_TowerPoints;
    }
}