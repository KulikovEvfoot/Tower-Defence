using System;
using Common.Timer;
using Services.Timer.Runtime;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class TowerAim : IReadOnlyAimData, ITimerCompleteObserver, IDisposable
    {
        public event Action<IShotTarget> OnAimTaken;
        
        private const float m_TakeAimDuration = 2f;//test
        
        private readonly SimpleTimer m_SimpleTimer;

        private IShotTarget m_CurrentTarget;
        private bool m_InProgress;
        
        public TowerAim(IGlobalTimer globalTimer)
        {
            var node = new TimerNode(m_TakeAimDuration, this);
            m_SimpleTimer = new SimpleTimer(globalTimer, node);
        }
        
        public bool IsAimTaken(IShotTarget shotTarget)
        {
            return m_CurrentTarget == shotTarget;
        }
        
        public void TakeAim(IShotTarget target)
        {
            m_CurrentTarget = target;
            
            if (m_InProgress)
            {
                return;
            }

            m_SimpleTimer.Start();
            m_InProgress = true;
        }

        void ITimerCompleteObserver.OnTimerComplete()
        {
            m_InProgress = false;
            
            OnAimTaken?.Invoke(m_CurrentTarget);
        }

        public void Dispose()
        {
            m_SimpleTimer?.Dispose();
        }
    }
}