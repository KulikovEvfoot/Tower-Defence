using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Timer.Runtime
{
    internal class SinceStartupTimerRunner : ITimerRunner
    {
        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();
        
        private readonly List<Tuple<TimerToken, TimerArgs>> m_ToAttach = new();
        private readonly List<TimerToken> m_ToDispose = new();
        
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
            foreach (var pair in m_Args)
            {
                var token = pair.Key;
                var args = m_Args[token];
                var pastTime  = args.StartTimeSinceStartup - Time.realtimeSinceStartup;
                var timeLeft = pastTime + args.Duration;
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
        
        private void ManagedAttach()
        {
            foreach (var tuple in m_ToAttach)
            {
                var token = tuple.Item1;
                m_Args.TryAdd(token, tuple.Item2);
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