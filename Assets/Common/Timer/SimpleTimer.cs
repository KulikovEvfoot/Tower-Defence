using System;
using Services.Timer.Runtime;

namespace Common.Timer
{
    public class SimpleTimer : IDisposable
    {
        private readonly IGlobalTimer m_GlobalTimer;
        private readonly TimerNode m_Node;
        
        private TimerToken m_TimerToken;

        public SimpleTimer(IGlobalTimer globalTimer, TimerNode node)
        {
            m_GlobalTimer = globalTimer;
            m_Node = node;
        }

        public void Start()
        {
            m_TimerToken?.Dispose();
            m_TimerToken = m_GlobalTimer.Begin(m_Node);
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            m_TimerToken?.Dispose();
        }
    }
}