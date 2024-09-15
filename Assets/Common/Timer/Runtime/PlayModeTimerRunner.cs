using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Timer.Runtime
{
    //TODO: вынести в одну абстракцию одинаковый код (SinceStartup)
    internal class PlayModeTimerRunner : ITimerRunner, ICanPaused
    {
        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();
        private readonly Dictionary<TimerToken, float> m_PauseDelay = new();

        private readonly List<Tuple<TimerToken, TimerArgs>> m_ToAttach = new();
        private readonly List<TimerToken> m_ToDispose = new();
        
        private bool m_IsPaused;
        private float m_PauseTime;
        
        public TimerToken Attach(TimerArgs args)
        {
            var token = new TimerToken(this);
            
            m_ToAttach.Add(new Tuple<TimerToken, TimerArgs>(token, args));
            
            return token;
        }
        
        public void Detach(TimerToken token)
        {
            m_ToDispose.Add(token);
        }

        public void Tick()     
        {
            if (m_IsPaused)
            {
                return;
            }

            ManagedAttach();
            
            foreach (var token in m_Args.Keys)
            {
                var args = m_Args[token];
                var pastTime  = args.StartTimeSinceStartup - Time.realtimeSinceStartup;
                var timeLeft = pastTime + args.Duration + m_PauseDelay[token];

                if (timeLeft <= float.Epsilon)
                {
                    args.TimerTickObserver.Tick(TimeSpan.Zero);
                    args.TimerCompleteObserver.OnTimerComplete();
                    
                    m_ToDispose.Add(token);
                    continue;
                }
                
                args.TimerTickObserver.Tick(TimeSpan.FromSeconds(timeLeft));
            }

            ManagedDispose();
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

        private void ManagedAttach()
        {
            foreach (var tuple in m_ToAttach)
            {
                var token = tuple.Item1;
                m_Args.Add(token, tuple.Item2);
                m_PauseDelay.Add(token, 0);
            }
            
            m_ToAttach.Clear();
        }
        
        private void ManagedDispose()
        {
            var toDisposeCount = m_ToDispose.Count;
            if (toDisposeCount > 0)
            {
                for (int i = toDisposeCount - 1; i >= 0; i--)
                {
                    var token = m_ToDispose[i];
                    m_Args.Remove(token);
                    m_PauseDelay.Remove(token);
                    
                    m_ToDispose.RemoveAt(i);
                }
            }
        }
        
        public void Dispose()
        {
            m_ToAttach.Clear();
            
            foreach (var arg in m_Args)
            {
                m_ToDispose.Add(arg.Key);
            }
            
            ManagedDispose();
        }
    }
}