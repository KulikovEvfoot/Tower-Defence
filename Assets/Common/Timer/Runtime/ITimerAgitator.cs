namespace Services.Timer.Runtime
{
    public interface ITimerAgitator
    {
        TimerToken Attach(TimerNode node);
        void Detach(TimerToken token);
    }
}