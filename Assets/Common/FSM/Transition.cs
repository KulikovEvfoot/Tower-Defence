using System;

namespace Common.FSM
{
    public class Transition
    {
        private readonly Func<bool> m_Condition;
        
        public Type To { get; }
        public Type From { get; }

        public Transition(Type from, Type to, Func<bool> condition)
        {
            From = from;
            To = to;
            m_Condition = condition;
        }

        public bool CanTranslate()
        {
            return m_Condition.Invoke();
        }
    }
}