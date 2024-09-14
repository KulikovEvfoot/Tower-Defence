using Common.FSM;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerIdleState : IEnterState
    {
        public void Enter()
        {
            Debug.Log("Idle");
        }
    }
}