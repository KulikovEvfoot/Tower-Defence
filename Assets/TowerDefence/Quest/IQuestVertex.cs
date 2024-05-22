using System;
using System.Collections.Generic;
using Common;

namespace TowerDefence.Quest
{
    public interface IQuestVertex
    {
        event Action OnEnter;
        event Action OnExit;

        void Run();
        Result<IQuestVertex> GetNext();
        IEnumerable<IQuestVertex> GetAllVertices();
    }
}