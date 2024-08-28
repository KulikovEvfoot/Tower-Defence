using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    internal class CrossbowWeapon : IShotStrategy, IDisposable
    {
        private readonly CrossbowAmmoSpawner m_CrossbowAmmoSpawner;
        private readonly CrossbowAmmoAnchorPoint m_CrossbowAmmoAnchorPoint;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly RifleDamageService m_RifleDamageService;
        private readonly CrossbowAmmoViewConfigurator m_CrossbowAmmoViewConfigurator;
        
        private readonly List<CrossbowShotSimulation> m_Simulations = new();

        internal CrossbowWeapon(CrossbowAmmoSpawner crossbowAmmoSpawner, CrossbowAmmoAnchorPoint anchorPoint, UpdateMaster updateMaster)
        {
            m_CrossbowAmmoSpawner = crossbowAmmoSpawner;
            m_CrossbowAmmoAnchorPoint = anchorPoint;
            m_UpdateMaster = updateMaster;
            m_RifleDamageService = new RifleDamageService();
            m_CrossbowAmmoViewConfigurator = new CrossbowAmmoViewConfigurator(); 
            
            m_UpdateMaster.OnUpdate += UpdateAmmoPosition;
        }

        public void Shot(IShotTarget target)
        {
            var ammo = m_CrossbowAmmoSpawner.Spawn();
            m_CrossbowAmmoViewConfigurator.Configure(m_CrossbowAmmoAnchorPoint, ammo);
            var simulation = new CrossbowShotSimulation(m_CrossbowAmmoAnchorPoint.Position, target, ammo);
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
            m_UpdateMaster.OnUpdate -= UpdateAmmoPosition;
        }
    }
}