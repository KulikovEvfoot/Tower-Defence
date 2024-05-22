using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefence.Launcher
{
    internal class StageManager
    {
        private readonly Dictionary<string, IStage> m_Stages = new();
        
        public void AddStage(IStage stage)
        {
            var isAdded = m_Stages.TryAdd(stage.Name, stage);
            if (!isAdded)
            {
                Debug.LogError($"[{nameof(StageManager)}]: Can't add stage with name = {stage.Name}. Entity already exists");
                return;
            }
        }
        
        public void Configure(IEnumerable<Tuple<Stage, IControlEntity>> meta)
        {
            var sortedEntitiesMeta = meta.OrderBy(i => i.Item1.Order).ToList();
            foreach (var (stageMeta, entity) in sortedEntitiesMeta)
            {
                if (!m_Stages.TryGetValue(stageMeta.Name, out var stage))
                {
                    return;
                }

                var entityName = entity.GetType().AssemblyQualifiedName;
                if (stage.HasEntity(entityName))
                {
                    return;
                }

                stage.AddEntity(entityName, entity);
            }
        }

        public List<IStage> GetStages()
        {
            return m_Stages.Values.ToList();
        }
    }
}