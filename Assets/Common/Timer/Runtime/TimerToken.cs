using System;

namespace Services.Timer.Runtime
{
    public class TimerToken : IDisposable
    {
        private readonly IGlobalTimer m_Timer;
        
        private bool m_IsDisposed;
        
        public string Mode { get; }

        public TimerToken(IGlobalTimer timer, string mode)
        {
            m_Timer = timer;
            Mode = mode;
        }

        public void Dispose()
        {
            if (m_IsDisposed)
            {
                return;
            }

            m_IsDisposed = true;
            m_Timer.Detach(this);
        }
    }
}