using Cysharp.Threading.Tasks;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface ITowerService
    {
        string Key { get; }
        
        UniTask Preload();
        void Init();
        ITowerFactory GetFactory();
    }
}