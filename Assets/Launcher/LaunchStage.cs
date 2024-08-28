using System.Collections.Generic;
using System.Linq;

namespace Launcher
{
    public class LaunchStage : IStage
    {
        private readonly Dictionary<string, IControlEntity> m_ControlEntities = new();
        
        public bool IsAsync { get; set; }
        public string Name { get; }

        public LaunchStage(string name)
        {
            Name = name;
        }

        public bool HasEntity(string key)
        {
            return m_ControlEntities.ContainsKey(key);
        }

        public void AddEntity(string key, IControlEntity entity)
        {
            m_ControlEntities.TryAdd(key, entity);
        }

        public void ClearEntities()
        {
            m_ControlEntities.Clear();
        }

        public IEnumerable<IControlEntity> GetEntities()
        { 
            return m_ControlEntities.Values.ToList();
        }
    }
}