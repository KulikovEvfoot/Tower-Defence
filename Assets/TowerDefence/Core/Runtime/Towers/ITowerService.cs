using Cysharp.Threading.Tasks;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface ITowerService
    {
        UniTask Preload();
        void Init();
        ITowerFactory GetFactory();
    }
}