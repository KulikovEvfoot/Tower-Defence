using UnityEngine;

namespace TowerDefence.Core.Runtime.Mock
{
    public class MockAmmo : IAmmo
    {
        public Transform Transform { get; set; }

        public MockAmmo(Transform transform)
        {
            Transform = transform;
        }
    }
}