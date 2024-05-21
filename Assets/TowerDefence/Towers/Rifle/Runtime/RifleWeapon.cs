using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace TowerDefence.Runtime.Rifle
{
    public class RifleWeapon : IShotStrategy, IDisposable
    {
        private readonly RifleAmmoSpawner m_RifleAmmoSpawner;
        private readonly Vector3 m_Sender;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly RifleDamageService m_RifleDamageService;
        
        private readonly List<RifleShotSimulation> m_Simulations = new();

        public RifleWeapon(RifleAmmoSpawner rifleAmmoSpawner, Vector3 sender, UpdateMaster updateMaster)
        {
            m_RifleAmmoSpawner = rifleAmmoSpawner;
            m_Sender = sender;
            m_UpdateMaster = updateMaster;
            
            m_UpdateMaster.OnUpdate += UpdateAmmoPosition;
        }

        public void Shot(IShotTarget target)
        {
            var bullet = m_RifleAmmoSpawner.Create(m_Sender);
            var simulation = new RifleShotSimulation(m_Sender, target, bullet);
            m_Simulations.Add(simulation);
        }

        private void UpdateAmmoPosition()
        {
            for (int i = 0; i < m_Simulations.Count; i++)
            {
                var simulation = m_Simulations[i];
                simulation.Move(Time.deltaTime);
                if (simulation.IsCompleted)
                {
                    m_RifleDamageService.DoDamage(simulation.Target);
                    m_Simulations.RemoveAt(i);
                }

                i--;
            }
        }

        public void Dispose()
        {
            if (m_UpdateMaster != null)
            {
                m_UpdateMaster.OnUpdate -= UpdateAmmoPosition;
            }
        }
    }
}