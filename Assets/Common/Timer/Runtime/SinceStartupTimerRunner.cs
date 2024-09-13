using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Timer.Runtime
{
    internal class SinceStartupTimerRunner : ITimerRunner
    {
        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();

        public TimerToken Attach(TimerArgs args)
        {
            var token = new TimerToken(this);
            m_Args.TryAdd(token, args);
            return token;
        }

        public void Detach(TimerToken token)
        {
            m_Args.Remove(token);
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
                    return;
                }
            
                args.TimerTickObserver.Tick(TimeSpan.FromSeconds(timeLeft));
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