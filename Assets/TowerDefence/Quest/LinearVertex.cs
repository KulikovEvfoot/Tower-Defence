using System;
using System.Collections.Generic;
using Common;

namespace TowerDefence.Quest
{
    public abstract class LinearVertex : IQuestVertex
    { 
        protected IQuestVertex m_NextVertex;

        public abstract event Action OnEnter;
        public abstract event Action OnExit;
        
        public abstract void Run();
        
        public virtual Result<IQuestVertex> GetNext()
        {
            return m_NextVertex != null ? Result<IQuestVertex>.Success(m_NextVertex) : Result<IQuestVertex>.Fail();
        }
        
        public IEnumerable<IQuestVertex> GetAllVertices()
        {
            return new[] { m_NextVertex };
        }
    }
}