using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Launcher
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

        public async UniTask Run()
        {
            var meta = m_ControlEntityManager.GetEntityMeta();
            m_StageManager.Configure(meta);
            var stages = m_StageManager.GetStages();

            foreach (var stage in stages)
            {
                await LoadResources(stage);
            }
            
            foreach (var stage in stages)
            {
                await Launch(stage);
            }
        }

        private async UniTask LoadResources(IStage stage)
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
                return;
            }
            
            foreach (var func in awaitAsyncCompletion)
            {
                if (func.Invoke())
                {
                    continue;
                }

                await UniTask.WaitUntil(func);
            }
        }

        private async UniTask Launch(IStage stage)
        {
            var controlEntities = stage.GetEntities();
            foreach (var entity in controlEntities)
            {
                entity.Launch();
                await UniTask.Yield();
            }
        }
    }
}