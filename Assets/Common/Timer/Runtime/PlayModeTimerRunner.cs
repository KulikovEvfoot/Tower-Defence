using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Timer.Runtime
{
    internal class PlayModeTimerRunner : ITimerRunner, ICanPaused
    {
        private bool m_IsPaused;
        private float m_PauseTime;

        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();
        private readonly Dictionary<TimerToken, float> m_PauseDelay = new();

        private readonly List<TimerToken> m_ToDetach = new();
        
        public TimerToken Attach(TimerArgs args)
        {
            var token = new TimerToken(this);
            m_Args.TryAdd(token, args);
            m_PauseDelay.TryAdd(token, 0);
            return token;
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

            foreach (var pair in m_Args)
            {
                var token = pair.Key;
                var args = m_Args[token];
                var pastTime  = args.StartTimeSinceStartup - Time.realtimeSinceStartup;
                var timeLeft = pastTime + args.Duration + m_PauseDelay[token];

                if (timeLeft <= float.Epsilon)
                {
                    args.TimerTickObserver.Tick(TimeSpan.Zero);
                    args.TimerCompleteObserver.OnTimerComplete();
                    
                    m_ToDetach.Add(token);
                    return;
                }
            
                args.TimerTickObserver.Tick(TimeSpan.FromSeconds(timeLeft));
            }

            var toDetachCount = m_ToDetach.Count;
            if (toDetachCount > 0)
            {
                for (int i = toDetachCount - 1; i < toDetachCount; i--)
                {
                    m_ToDetach.RemoveAt(i);
                }
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

                var temp = new List<TimerToken>(m_PauseDelay.Keys);
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