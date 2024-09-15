using System;

namespace Common.Timer.Runtime
{
    public interface ITimerTickObserver
    {
        void Tick(TimeSpan timeSpan);
    }
}