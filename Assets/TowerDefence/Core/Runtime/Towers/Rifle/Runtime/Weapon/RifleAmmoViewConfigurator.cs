namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class RifleAmmoViewConfigurator
    {
        public void Configure(RifleAmmoAnchorPoint anchorPoint, RifleAmmo rifleAmmo)
        {
            rifleAmmo.SetParent(anchorPoint.Parent);
            rifleAmmo.Position = anchorPoint.Position;
            rifleAmmo.Rotation = anchorPoint.Rotation;
        }
    }
}