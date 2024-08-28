using Common;

namespace TowerDefence.Core.Runtime.Towers
{
    public interface ITowerFactory
    {
        Result<ITower> Create(int pointId, TowerLevel towerLevel);
    }
}