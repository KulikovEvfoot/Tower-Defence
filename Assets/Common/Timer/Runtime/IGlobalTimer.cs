using System;

namespace Services.Timer.Runtime
{
    public interface IGlobalTimer : ITimerAgitator, IDisposable
    {
        void Pause(bool isPause);
    }
}