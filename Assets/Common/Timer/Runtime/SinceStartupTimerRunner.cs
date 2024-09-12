using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.Timer.Runtime
{
    internal class SinceStartupTimerRunner : ITimerRunner
    {
        private readonly Dictionary<TimerToken, TimerArgs> m_Args = new();

        public void Attach(TimerToken token, TimerArgs args)
        {
            m_Args.TryAdd(token, args);
        }

        public void Detach(TimerToken token)
        {
            m_Args.Remove(token);
        }

        public void Tick()
        {
            foreach (var token in m_Args.Keys)
            {
                var args = m_Args[token];
                var pastTime  = args.StartTimeSinceStartup - Time.realtimeSinceStartup;
                var timeLeft = pastTime + args.Duration;

                if (timeLeft <= float.Epsilon)
                {
                    args.TimerObserver.Tick(TimeSpan.Zero);
                    args.TimerObserver.OnTimerComplete();
                    return;
                }
            
                args.TimerObserver.Tick(TimeSpan.FromSeconds(timeLeft));
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