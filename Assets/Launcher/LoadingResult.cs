using System;

namespace TowerDefence.Launcher
{
    public readonly struct LoadingResult
    {
        public static LoadingResult Sync => new LoadingResult(false, null);

        public readonly bool IsAsync;
        public readonly Func<bool> IsLoaded;

        public LoadingResult(bool isAsync, Func<bool> isLoaded)
        {
            IsAsync = isAsync;
            IsLoaded = isLoaded;
        }
    }
}