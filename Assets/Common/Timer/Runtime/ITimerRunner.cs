using System;

namespace Services.Timer.Runtime
{
    internal interface ITimerRunner : IDisposable
    {
        TimerToken Attach(TimerArgs args);
        void Detach(TimerToken token);
        void Tick();
    }
}