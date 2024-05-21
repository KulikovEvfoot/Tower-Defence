using TowerDefence.Core.Runtime;
using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime.Weapon
{
    internal class RifleAmmo : IAmmo
    {
        public RifleAmmoView View { get; }

        public Vector3 Position
        {
            get => View.Position;
            set => View.Position = value;
        }
        
        internal RifleAmmo(RifleAmmoView view)
        {
            View = view;
        }
    }
}