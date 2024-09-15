using Cysharp.Threading.Tasks;

namespace TowerDefence.Core.Runtime.Towers
{
    public interface ITowerService
    {
        string Key { get; }
        
        UniTask Preload();
        void Init();
        ITowerFactory GetFactory();
    }
}