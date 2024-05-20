using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class BulletShot : IShotStrategy
    {
        private BulletSpawner m_BulletSpawner;
        private Vector3 m_Sender;

        private readonly LinkedList<BulletShotSimulation> m_Simulations = new();
    
        public void Shot(IShotTarget target)
        {
            var simulation = new BulletShotSimulation();
            m_Simulations.AddLast(simulation);
        }
    }
}