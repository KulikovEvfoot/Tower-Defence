using System;

namespace Common.Timer.Runtime
{
    internal class StubTimerTickObserver : ITimerTickObserver
    {
        public void Tick(TimeSpan timeSpan) { }
    }
}