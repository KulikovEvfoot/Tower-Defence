using System.Collections.Generic;

namespace TowerDefence.Launcher
{
    public interface IStage
    {
        bool IsAsync { get; set; }
        string Name { get; }
        
        bool HasEntity(string key);
        void AddEntity(string key, IControlEntity entity);
        IEnumerable<IControlEntity> GetEntities();
        void ClearEntities();
    }
}