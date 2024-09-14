using System;
using System.Linq;

namespace Common.FSM
{
    public class SimpleStateMachine : IStateMachine
    {
        private readonly IState[] m_States;
        private readonly Transition[] m_Transitions;

        private IState m_Current;
        
        public SimpleStateMachine(IState[] states, Transition[] transitions)
        {
            m_States = states;
            m_Transitions = transitions;

            m_Current = m_States[0];
            if (m_Current is IEnterState enterState)
            {
                enterState.Enter();
            }
        }

        public void Update()
        {
            if (m_Current is IUpdateState updateState)
            {
                updateState.Update();
            }

            foreach (var transition in m_Transitions)
            {
                if (transition.From == m_Current.GetType() && transition.CanTranslate())
                {
                    TranslateTo(transition.To);
                }
            }
        }

        private void TranslateTo(Type toType)
        {
            if (m_Current is IExitState exitState)
            {
                exitState.Exit();
            }

            m_Current = m_States.First(x => x.GetType() == toType);
            
            if (m_Current is IEnterState enterState)
            {
                enterState.Enter();
            }
        }
    }
}