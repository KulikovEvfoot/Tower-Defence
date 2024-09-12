namespace Services.Timer.Runtime
{
    public class TimerNode
    {
        public ITimerObserver TimerObserver { get; }
        public float Duration { get; }
        public bool OnlyPlayMode { get; }
        
        public TimerNode(
            ITimerObserver timerObserver,
            float duration, 
            bool onlyPlayMode = false)
        {
            TimerObserver = timerObserver;
            Duration = duration;
            OnlyPlayMode = onlyPlayMode;
        }
    }
}