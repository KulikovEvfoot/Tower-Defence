using System;

namespace TowerDefence.Quest
{
    public class StubLinearVertex : LinearVertex
    {
        public override event Action OnEnter;
        public override event Action OnExit;

        public StubLinearVertex(IQuestVertex nextVertex)
        {
            m_NextVertex = nextVertex;
        }

        public override void Run()
        {
            OnEnter?.Invoke();
            OnExit?.Invoke();
        }
    }
}