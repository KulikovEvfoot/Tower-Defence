using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.Timer.Runtime
{
    internal class PlayModeTimerRunner : ITimerRunner, ICanPaused
    {
        private bool m_IsPaused;
        private float m_PauseTime;

        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();
        private readonly Dictionary<TimerToken, float> m_PauseDelay = new();

        public void Attach(TimerToken token, TimerArgs args)
        {
            m_Args.TryAdd(token, args);
            m_PauseDelay.TryAdd(token, 0);
        }

        public void Detach(TimerToken token)
        {
            m_Args.Remove(token);
            m_PauseDelay.Remove(token);
        }

        public void Tick()     
        {
            if (m_IsPaused)
            {
                return;
            }

            foreach (var token in m_Args.Keys)
            {
                var args = m_Args[token];
                var pastTime  = args.StartTimeSinceStartup - Time.realtimeSinceStartup;
                var timeLeft = pastTime + args.Duration + m_PauseDelay[token];

                if (timeLeft <= float.Epsilon)
                {
                    args.TimerObserver.Tick(TimeSpan.Zero);
                    args.TimerObserver.OnTimerComplete();
                    return;
                }
            
                args.TimerObserver.Tick(TimeSpan.FromSeconds(timeLeft));
            }
        }

        public void SetPause(bool isPaused)
        {
            if (m_IsPaused == isPaused)
            {
                Debug.LogError($"Can't toggle the timer state. Condition already = {m_IsPaused}");
                return;
            }
            
            m_IsPaused = isPaused;

            if (isPaused)
            {
                m_PauseTime = Time.realtimeSinceStartup;
            }
            else
            {
                var pauseDuration = Time.realtimeSinceStartup - m_PauseTime;

                var temp = m_PauseDelay.Keys.ToList();
                foreach (var token in temp)
                {
                    m_PauseDelay[token] += pauseDuration;
                }
            }
        }

        public void Dispose()
        {
            foreach (var token in m_Args.Keys)
            {
                token.Dispose();
            }
        }
    }
}