namespace TowerDefence.Quest
{
    public class SimpleQuestMachine : IQuestMachine
    {
        private readonly IQuestVertex m_MainQuestVertex;

        private bool m_IsRunning;

        public SimpleQuestMachine(IQuestVertex mainQuestVertex)
        {
            m_MainQuestVertex = mainQuestVertex;
        }

        public void Run()
        {
            if (m_IsRunning)
            {
                return;
            }
            
            m_IsRunning = true;

            m_MainQuestVertex.Run();
        }
    }
}