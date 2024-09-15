namespace Common.Timer.Runtime
{
    public interface IGlobalTimer
    {
        TimerToken Begin(TimerNode node);
        void Pause(bool isPause);
    }
}