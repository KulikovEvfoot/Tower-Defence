using System;
using System.Collections.Generic;
using Common;

namespace TowerDefence.Quest
{
    public class QuestArgsContainer : IQuestArgsContainer
    {
        public event Action<IQuestArg> OnQuestArgsChanged;
        
        private readonly Dictionary<Type, IQuestArg> m_QuestArgsMap = new ();
        
        public void SetQuestArg(IQuestArg questArg)
        {
            var type = questArg.GetType();

            var isAdded = m_QuestArgsMap.TryAdd(type, questArg);
            if (!isAdded)
            {
                m_QuestArgsMap[type] = questArg;
            }

            OnQuestArgsChanged?.Invoke(questArg);
        }

        public Result<T> GetQuestArg<T>() where T : IQuestArg
        {
            var type = typeof(T);
            if (m_QuestArgsMap.TryGetValue(type, out var args))
            {
                return Result<T>.Success((T)args);
            }
            
            return Result<T>.Fail();
        }

        public void RemoveQuestArgs<T>() where T : IQuestArg
        {
            var type = typeof(T);
            m_QuestArgsMap.Remove(type);
        }

        public void ClearAllArgs()
        {
            m_QuestArgsMap.Clear();
        }
    }
}