using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers
{
    public class TestMonoShotTarget : MonoBehaviour, IShotTarget
    {
        public Vector3 Position => transform.position;
    }
}