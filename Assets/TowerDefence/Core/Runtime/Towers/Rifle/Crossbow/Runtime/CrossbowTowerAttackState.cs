using Common.FSM;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerAttackState : IEnterState
    {
        private readonly IShotStrategy m_ShotStrategy;
        private readonly IAttackPriorityCollection<IShotTarget> m_AttackPriorityCollection;

        public CrossbowTowerAttackState(
            IShotStrategy shotStrategy,
            IAttackPriorityCollection<IShotTarget> attackPriorityCollection)
        {
            m_ShotStrategy = shotStrategy;
            m_AttackPriorityCollection = attackPriorityCollection;
        }

        public void Enter()
        {
            Debug.Log("Attack");

            if (!m_AttackPriorityCollection.HasNext())
            {
                return;
            }

            var target = m_AttackPriorityCollection.GetNext();
            m_ShotStrategy.Shot(target);
            
        }
    }
}