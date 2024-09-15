namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon
{
    public class CrossbowAmmoViewConfigurator
    {
        public void Configure(CrossbowAmmoAnchorPoint anchorPoint, CrossbowAmmo crossbowAmmo)
        {
            var transform = crossbowAmmo.Transform;
            transform.SetParent(anchorPoint.Parent);
            transform.position = anchorPoint.Position;
            transform.rotation = anchorPoint.Rotation;
        }
    }
}