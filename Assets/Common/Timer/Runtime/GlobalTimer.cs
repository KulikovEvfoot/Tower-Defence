using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Timer.Runtime
{
    public class GlobalTimer : IGlobalTimer, IDisposable
    {
        private readonly WaitForSecondsRealtime m_TickInterval = new WaitForSecondsRealtime(0.1f);
        private readonly Dictionary<string, ITimerRunner> m_TimerRunners;
        private readonly ICoroutineRunner m_TimerCoroutineRunner;
        
        private Coroutine m_TimerRoutine;
        
        public GlobalTimer(ICoroutineRunner timerCoroutineRunner)
        {
            m_TimerCoroutineRunner = timerCoroutineRunner;
            
            m_TimerRunners = new Dictionary<string, ITimerRunner>
            {
                [TimerEnvironment.SinceStartupMode] = new SinceStartupTimerRunner(),
                [TimerEnvironment.OnlyPlayMode] = new PlayModeTimerRunner()
            };
            
            // m_TimerRoutine = m_TimerCoroutineRunner.StartCoroutine(Run());
        }
        
        public TimerToken Begin(TimerNode node)
        {
            m_TimerRoutine ??= m_TimerCoroutineRunner.StartCoroutine(Run());
            
            var key = node.OnlyPlayMode 
                ? TimerEnvironment.OnlyPlayMode 
                : TimerEnvironment.SinceStartupMode;

            var timerArgs = new TimerArgs(
                Time.realtimeSinceStartup,
                node.Duration,
                node.TimerTickObserver,
                node.TimerCompleteObserver);
            
            var token = m_TimerRunners[key].Attach(timerArgs);
            return token;
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
            foreach (var pair in m_TimerRunners)
            {
                pair.Value.Tick();
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