using System;

namespace Services.Timer.Runtime
{
    public interface ITimerTickObserver
    {
        void Tick(TimeSpan timeSpan);
    }
}