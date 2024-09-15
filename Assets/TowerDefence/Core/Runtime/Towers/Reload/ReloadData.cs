using System;

namespace TowerDefence.Core.Runtime.Towers.Reload
{
    public class ReloadData : IReadOnlyReloadData
    {
        public event Action OnReloaded;
        public event Action OnOutOfAmmo;

        public int MagazineCapacity { get; }
        public float ReloadTime { get; }
        
        public int AmmoCount { get; private set; }

        public ReloadData(int magazineCapacity, float reloadTime)
        {
            MagazineCapacity = magazineCapacity;
            ReloadTime = reloadTime;

            AmmoCount = MagazineCapacity;
        }

        public void Use()
        {
            if (HasAmmo())
            {
                AmmoCount--;
            }
            
            if (!HasAmmo())
            {
                OnOutOfAmmo?.Invoke();
            }
        }
        
        public void Reload()
        {
            AmmoCount = MagazineCapacity;
            OnReloaded?.Invoke();
        }
        
        public bool HasAmmo()
        {
            return AmmoCount > 0;
        }
    }
}