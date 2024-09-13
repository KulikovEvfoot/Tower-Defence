using System;

namespace Services.Timer.Runtime
{
    public interface IGlobalTimer : IDisposable
    {
        TimerToken Begin(TimerNode node);
        void Pause(bool isPause);
    }
}