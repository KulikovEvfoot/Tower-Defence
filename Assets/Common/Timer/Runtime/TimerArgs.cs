namespace Common.Timer.Runtime
{
    internal class TimerArgs
    {
        public float StartTimeSinceStartup { get; }
        public float Duration { get; }
        public ITimerTickObserver TimerTickObserver { get; }
        public ITimerCompleteObserver TimerCompleteObserver { get; }

        public TimerArgs(
            float startTimeSinceStartup, 
            float duration, 
            ITimerTickObserver timerTickObserver,
            ITimerCompleteObserver timerCompleteObserver)
        {
            StartTimeSinceStartup = startTimeSinceStartup;
            Duration = duration;
            TimerTickObserver = timerTickObserver;
            TimerCompleteObserver = timerCompleteObserver;
        }
    }
}