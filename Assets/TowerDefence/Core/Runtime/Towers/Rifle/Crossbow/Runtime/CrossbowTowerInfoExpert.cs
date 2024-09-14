namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerInfoExpert
    {
        private readonly IAttackPriorityCollection<IShotTarget> m_AttackPriorityCollection;

        public IReadOnlyReloadData ReloadData { get; }
        public IReadOnlyAimData AimData { get; }
        
        public IShotTarget CurrentTarget { get; set; }
        
        public CrossbowTowerInfoExpert(
            IReadOnlyReloadData reloadData, 
            IReadOnlyAimData aimData, 
            IAttackPriorityCollection<IShotTarget> attackPriorityCollection)
        {
            ReloadData = reloadData;
            AimData = aimData;
            m_AttackPriorityCollection = attackPriorityCollection;
        }
        
        public bool HasEnemyInRange()
        {
            return m_AttackPriorityCollection.HasNext();
        }

        public bool IsAimTaken()
        {
            if (CurrentTarget == null)
            {
                return false;
            }
            
            return AimData.IsAimTaken(CurrentTarget);
        }
    }
}