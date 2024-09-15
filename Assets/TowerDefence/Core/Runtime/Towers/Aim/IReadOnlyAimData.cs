using System;

namespace TowerDefence.Core.Runtime.Towers.Aim
{
    public interface IReadOnlyAimData
    {
        event Action<IShotTarget> OnAimTaken;

        bool IsAimTaken(IShotTarget shotTarget);
    }
}