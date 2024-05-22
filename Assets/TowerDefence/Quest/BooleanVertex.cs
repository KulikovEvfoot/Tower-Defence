using System;
using System.Collections.Generic;
using Common;

namespace TowerDefence.Quest
{
    public abstract class BooleanVertex : IQuestVertex
    { 
        protected IEnumerable<IQuestVertex> m_NextVertices;

        public abstract event Action OnEnter;
        public abstract event Action OnExit;
        
        public abstract void Run();

        public abstract Result<IQuestVertex> GetNext();
        
        public IEnumerable<IQuestVertex> GetAllVertices()
        {
            return m_NextVertices;
        }
    }
}