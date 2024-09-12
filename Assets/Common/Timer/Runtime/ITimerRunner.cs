using System;

namespace Services.Timer.Runtime
{
    internal interface ITimerRunner : IDisposable
    {
        void Attach(TimerToken token, TimerArgs args);
        void Detach(TimerToken token);
        void Tick();
    }
}