using Common.FSM;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerWeaponAimingState : IEnterState
    {
        private readonly ICanTakeAim m_TowerAim;
        private readonly ICanReload m_TowerRecharger;
        
        public CrossbowTowerWeaponAimingState(ICanTakeAim towerAim, ICanReload towerRecharger)
        {
            m_TowerAim = towerAim;
            m_TowerRecharger = towerRecharger;
        }

        public void Enter()
        {
            Debug.Log("Take aim");
            
            m_TowerAim.TakeAim();
            m_TowerRecharger.Reload();
        }
    }
}