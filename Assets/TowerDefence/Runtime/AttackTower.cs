namespace TowerDefence.Runtime
{
    public class AttackTower
    {
        private IShotStrategy m_ShotStrategy;
    
        public int Id { get; }
    
        public void Shoot(IShotTarget target)
        {
            m_ShotStrategy.Shot(target);
        }
    }
}