using System;
using Common;

namespace TowerDefence.Quest
{
    public interface IQuestArgsContainer
    {
        event Action<IQuestArg> OnQuestArgsChanged;

        void SetQuestArg(IQuestArg questArg);
        Result<T> GetQuestArg<T>() where T : IQuestArg;
        void RemoveQuestArgs<T>() where T : IQuestArg;
        void ClearAllArgs();
    }
}