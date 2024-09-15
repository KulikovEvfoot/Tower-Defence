using System;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Scene.Scene
{
    [Serializable]
    public class TowerWaypoint
    {
        [SerializeField] private int m_PointId;
        [SerializeField] private Vector3 m_Position;

        public int PointId => m_PointId;
        public Vector3 Position => m_Position;
    }
}