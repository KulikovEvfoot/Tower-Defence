namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerInfoExpert
    {
        public IAttackPriorityCollection<IShotTarget> AttackPriority { get; }
        public IReadOnlyReloadData ReloadData { get; }
        public IReadOnlyAimData AimData { get; }
        
        public IShotTarget CurrentTarget { get; set; }
        
        public CrossbowTowerInfoExpert(
            IReadOnlyReloadData reloadData, 
            IReadOnlyAimData aimData, 
            IAttackPriorityCollection<IShotTarget> attackPriority)
        {
            ReloadData = reloadData;
            AimData = aimData;
            AttackPriority = attackPriority;
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