using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TowerDefence.Launcher
{
    public class LaunchWizard
    {
        private readonly StageManager m_StageManager = new StageManager();
        private readonly ControlEntityManager m_ControlEntityManager = new ControlEntityManager();
        
        public LaunchWizard AddStage(IStage stage)
        {
            m_StageManager.AddStage(stage);
            return this;
        }

        public void AddControlEntities(IEnumerable<IControlEntity> controlEntities)
        {
            m_ControlEntityManager.AddAControlEntities(controlEntities);
        }

        public IEnumerator Run()
        {
            var meta = m_ControlEntityManager.GetEntityMeta();
            m_StageManager.Configure(meta);
            var stages = m_StageManager.GetStages();

            foreach (var stage in stages)
            {
                yield return LoadResources(stage);
            }
            
            foreach (var stage in stages)
            {
                yield return Launch(stage);
            }
            
            yield return null;
        }

        private IEnumerator LoadResources(IStage stage)
        {
            var controlEntities = stage.GetEntities();
            var awaitAsyncCompletion = new List<Func<bool>>();
            foreach (var entity in controlEntities)
            {
                var loadingResult =  entity.LoadResources();
                if (loadingResult.IsAsync)
                {
                    stage.IsAsync = true;
                    awaitAsyncCompletion.Add(loadingResult.IsLoaded);
                }
            }

            if (!stage.IsAsync)
            {
                yield break;
            }
            
            //пока так
            while (awaitAsyncCompletion.All(a => a.Invoke()))
            {
                yield return null;
            }
        }

        private IEnumerator Launch(IStage stage)
        {
            var controlEntities = stage.GetEntities();
            foreach (var entity in controlEntities)
            {
                entity.Launch();
                yield return null;
            }
        }
    }
}