using System;

namespace Common.Timer.Runtime
{
    public class TimerToken : IDisposable
    {
        private readonly ITimerRunner m_Runner;
        
        private bool m_IsDisposed;
        
        internal TimerToken(ITimerRunner runner)
        {
            m_Runner = runner;
        }

        public void Dispose()
        {
            if (m_IsDisposed)
            {
                return;
            }

            m_IsDisposed = true;
            m_Runner.Detach(this);
        }
    }
}