namespace TowerDefence.Runtime
{
    public class RifleTower
    {
        private IShotStrategy m_ShotStrategy;
    
        public int Id { get; }
    
        public void Shoot(IShotTarget target)
        {
            m_ShotStrategy.Shot(target);
        }
    }
}