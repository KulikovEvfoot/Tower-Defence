namespace Services.Timer.Runtime
{
    internal class TimerArgs
    {
        public float StartTimeSinceStartup { get; }
        public float Duration { get; }
        public ITimerObserver TimerObserver { get; }

        public TimerArgs(
            float startTimeSinceStartup, 
            float duration, 
            ITimerObserver timerObserver)
        {
            StartTimeSinceStartup = startTimeSinceStartup;
            Duration = duration;
            TimerObserver = timerObserver;
        }
    }
}