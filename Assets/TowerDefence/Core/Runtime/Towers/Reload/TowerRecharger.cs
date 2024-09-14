using System;
using Common.Timer;
using Services.Timer.Runtime;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class TowerRecharger : ITimerCompleteObserver, IDisposable
    {
        event Action<float> OnStartReload;
        
        private readonly ReloadData m_ReloadData;
        private readonly SimpleTimer m_SimpleTimer;
        
        private bool m_InProgress;

        public TowerRecharger(ReloadData reloadData, IGlobalTimer globalTimer)
        {
            m_ReloadData = reloadData;
            
            var node = new TimerNode(m_ReloadData.ReloadTime, this);
            m_SimpleTimer = new SimpleTimer(globalTimer, node);
        }
        
        public void Reload()
        {
            if (!m_ReloadData.HasAmmo() || m_InProgress)
            {
                return;
            }

            m_SimpleTimer.Start();
            
            m_InProgress = true;
            
            OnStartReload?.Invoke(m_ReloadData.ReloadTime);
        }

        void ITimerCompleteObserver.OnTimerComplete()
        {
            m_InProgress = false;
            m_ReloadData.Reload();
        }

        public void Dispose()
        {
            m_SimpleTimer?.Dispose();
        }
    }
}