namespace TowerDefence.Quest
{
    public abstract class SingleQuestArg<T> : IQuestArg
    {
        public T Value { get; }

        protected SingleQuestArg(T value)
        {
            Value = value;
        }
    }
}