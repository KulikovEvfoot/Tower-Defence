using System;

namespace TowerDefence.Core.Runtime.Towers.Reload
{
    public interface IReadOnlyReloadData
    {
        event Action OnReloaded;
        event Action OnOutOfAmmo;        
        
        int MagazineCapacity { get; }
        float ReloadTime { get; }
        
        bool HasAmmo();
    }
}