namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    internal class RifleAmmoViewConfigurator
    {
        private readonly RifleAmmoAnchorPoint m_AnchorPoint;

        public RifleAmmoViewConfigurator(RifleAmmoAnchorPoint anchorPoint)
        {
            m_AnchorPoint = anchorPoint;
        }

        internal void Configure(RifleAmmoView rifleAmmo)
        {
            rifleAmmo.SetParent(m_AnchorPoint.Parent);
            rifleAmmo.Position = m_AnchorPoint.Position;
            rifleAmmo.Rotation = m_AnchorPoint.Rotation;
        }
    }
}