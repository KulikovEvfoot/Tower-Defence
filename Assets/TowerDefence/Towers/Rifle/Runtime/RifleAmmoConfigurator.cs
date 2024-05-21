using UnityEngine;

namespace TowerDefence.Runtime
{
    public class RifleAmmoConfigurator
    {
        public void Configure(RifleAmmo rifleAmmo, Vector3 position)
        {
            rifleAmmo.Position = position;
        }
    }
}