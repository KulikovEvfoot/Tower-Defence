using System;
using System.Collections.Generic;
using Common;
using TowerDefence.Core.Runtime;
using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    internal class RifleWeapon : IShotStrategy, IDisposable
    {
        private readonly RifleAmmoSpawner m_RifleAmmoSpawner;
        private readonly RifleAmmoAnchorPoint m_RifleAmmoAnchorPoint;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly RifleDamageService m_RifleDamageService;
        
        private readonly List<RifleShotSimulation> m_Simulations = new();

        internal RifleWeapon(RifleAmmoSpawner rifleAmmoSpawner, RifleAmmoAnchorPoint anchorPoint, UpdateMaster updateMaster)
        {
            m_RifleAmmoSpawner = rifleAmmoSpawner;
            m_RifleAmmoAnchorPoint = anchorPoint;
            m_UpdateMaster = updateMaster;
            m_RifleDamageService = new RifleDamageService();
            
            m_UpdateMaster.OnUpdate += UpdateAmmoPosition;
        }

        public void Shot(IShotTarget target)
        {
            var ammo = m_RifleAmmoSpawner.Spawn();
            var simulation = new RifleShotSimulation(m_RifleAmmoAnchorPoint.Position, target, ammo);
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