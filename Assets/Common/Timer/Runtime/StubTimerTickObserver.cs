using System;

namespace Services.Timer.Runtime
{
    internal class StubTimerTickObserver : ITimerTickObserver
    {
        public void Tick(TimeSpan timeSpan) { }
    }
}