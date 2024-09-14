using System;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface IReadOnlyAimData
    {
        event Action<IShotTarget> OnAimTaken;

        bool IsAimTaken(IShotTarget shotTarget);
    }
}