using System;
using System.Collections.Generic;
using Common;

namespace TowerDefence.Quest
{
    public class QuestMachine
    {
        
    }

    public class QuestGraph
    {
        
        
    }

    public interface IQuestVertex
    {
        event Action OnEnter;
        event Action OnExit;

        void Run();
        Result<IQuestVertex> GetNext();
        IEnumerable<IQuestVertex> GetAllVertices();
    }
    
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
    
    public class TestVertex : LinearVertex
    {
        public override event Action OnEnter;
        public override event Action OnExit;

        public override void Run()
        {
            OnEnter?.Invoke();
        }
    }
}