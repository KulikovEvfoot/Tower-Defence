namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon
{
    public class CrossbowAmmoViewConfigurator
    {
        public void Configure(CrossbowAmmoAnchorPoint anchorPoint, CrossbowAmmo crossbowAmmo)
        {
            crossbowAmmo.SetParent(anchorPoint.Parent);
            crossbowAmmo.Position = anchorPoint.Position;
            crossbowAmmo.Rotation = anchorPoint.Rotation;
        }
    }
}