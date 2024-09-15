namespace Common.Timer.Runtime
{
    public class TimerNode
    {
        public float Duration { get; }
        public ITimerTickObserver TimerTickObserver { get; }
        public ITimerCompleteObserver TimerCompleteObserver { get; }
        public bool OnlyPlayMode { get; }
        
        public TimerNode(
            float duration, 
            ITimerObserver timerObserver,
            bool onlyPlayMode = true)
        {
            TimerTickObserver = timerObserver;
            TimerCompleteObserver = timerObserver;
            Duration = duration;
            OnlyPlayMode = onlyPlayMode;
        }
        
        public TimerNode(
            float duration, 
            ITimerTickObserver timerTickObserver,
            bool onlyPlayMode = true)
        {
            TimerTickObserver = timerTickObserver;
            TimerCompleteObserver = new StubTimerCompleteObserver();
            Duration = duration;
            OnlyPlayMode = onlyPlayMode;
        }
        
        public TimerNode(
            float duration, 
            ITimerCompleteObserver timerCompleteObserver,
            bool onlyPlayMode = true)
        {
            TimerTickObserver = new StubTimerTickObserver();
            TimerCompleteObserver = timerCompleteObserver;
            Duration = duration;
            OnlyPlayMode = onlyPlayMode;
        }
    }
}