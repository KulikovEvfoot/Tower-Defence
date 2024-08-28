using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.Config;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface ITowerService
    {
        string Key { get; }
        
        UniTask Preload();
        void Init(ILocationBalanceFacade locationBalanceFacade);
        ITowerFactory GetFactory();
    }
}