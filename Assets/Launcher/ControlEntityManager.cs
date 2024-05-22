using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefence.Launcher
{
    internal class ControlEntityManager
    {
        private readonly Dictionary<string, IControlEntity> m_ControlEntitiesMap = new();
        
        public void AddAControlEntities(IEnumerable<IControlEntity> controlEntities)
        {
            foreach (var controlEntity in controlEntities)
            {
                var entityName = controlEntity.GetType().AssemblyQualifiedName;
                var isAdded = m_ControlEntitiesMap.TryAdd(entityName, controlEntity);
                if (!isAdded)
                {
                    Debug.LogError($"[{nameof(ControlEntityManager)}]: Can't add entity with name = {entityName}. Entity already exists");
                }
            }
        }
        
        public IEnumerable<Tuple<Stage, IControlEntity>> GetEntityMeta()
        {
            foreach (var controlEntity in m_ControlEntitiesMap.Values)
            {
                var attributes = controlEntity.GetType().GetCustomAttributes(typeof(Stage), false);
                foreach (var attribute in attributes)
                {
                    var stageAttribute = attribute as Stage;
                    yield return new Tuple<Stage, IControlEntity>(stageAttribute, controlEntity);
                }
            }
        }
        
        public List<IControlEntity> GetControlEntities()
        {
            return m_ControlEntitiesMap.Values.ToList();
        }
    }
}