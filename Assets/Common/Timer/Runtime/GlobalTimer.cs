using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Services.Timer.Runtime
{
    public class GlobalTimer : IGlobalTimer
    {
        private readonly WaitForSecondsRealtime m_TickInterval = new WaitForSecondsRealtime(0.1f);
        private readonly Dictionary<string, ITimerRunner> m_TimerRunners;
        private readonly ICoroutineRunner m_TimerCoroutineRunner;
        private readonly Coroutine m_TimerRoutine;
        
        public GlobalTimer(ICoroutineRunner timerCoroutineRunner)
        {
            m_TimerCoroutineRunner = timerCoroutineRunner;
            
            m_TimerRunners = new Dictionary<string, ITimerRunner>
            {
                [TimerEnvironment.SinceStartupMode] = new SinceStartupTimerRunner(),
                [TimerEnvironment.OnlyPlayMode] = new PlayModeTimerRunner()
            };
            
            m_TimerRoutine = m_TimerCoroutineRunner.StartCoroutine(Run());
        }
        
        public TimerToken Attach(TimerNode node)
        {
            var key = node.OnlyPlayMode 
                ? TimerEnvironment.OnlyPlayMode 
                : TimerEnvironment.SinceStartupMode;
            
            var token = new TimerToken(this, key);
            
            m_TimerRunners[key].Attach(token, new TimerArgs(
                Time.realtimeSinceStartup, 
                node.Duration, 
                node.TimerObserver));
            
            return token;
        }

        public void Detach(TimerToken token)
        {
            m_TimerRunners[token.Mode]?.Detach(token);
        }

        public void Stop()
        {
            if (m_TimerCoroutineRunner != null && m_TimerRoutine != null)
            {
                m_TimerCoroutineRunner.StopCoroutine(m_TimerRoutine);
            }
        }

        public void Pause(bool isPause)
        {
            foreach (var timerRunner in m_TimerRunners.Values)
            {
                if (timerRunner is ICanPaused canPaused)
                {
                    canPaused.SetPause(isPause);
                }
            }
        }
        
        private IEnumerator Run()
        {
            while (true)
            {
                Tick();
                yield return m_TickInterval;
            }
        }

        private void Tick()
        {
            foreach (var timerRunner in m_TimerRunners.Values)
            {
                timerRunner.Tick();
            }
        }

        public void Dispose()
        {
            Stop();
            
            foreach (var timerRunner in m_TimerRunners.Values)
            {
                timerRunner.Dispose();
            }
        }
        
        ~GlobalTimer()
        {
            Dispose();
        }
    }
}