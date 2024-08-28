using Common;

namespace TowerDefence.Core.Runtime.Towers
{
    public interface ITowerServices
    {
        Result<ITowerFactory> GetFactory(string name);
    }
}