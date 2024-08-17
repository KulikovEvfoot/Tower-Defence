namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleTower : ITower
    {
        private readonly RifleTowerView m_TowerView;
        private readonly IShotStrategy m_ShotStrategy;

        public int Id { get; }

        public RifleTower(int id, RifleTowerView view, IShotStrategy shotStrategy)
        {
            Id = id;
            m_TowerView = view;
            m_ShotStrategy = shotStrategy;
        }

        public void Shoot(IShotTarget target)
        {
            m_ShotStrategy.Shot(target);
        }
    }
}