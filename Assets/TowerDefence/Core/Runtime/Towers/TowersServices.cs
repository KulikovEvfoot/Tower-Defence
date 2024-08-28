using System;
using System.Collections.Generic;
using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers
{
    public class TowersServices : ITowerServices
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly Dictionary<string, ITowerService> m_TowerServices;
        private readonly ILogger m_Logger;

        public TowersServices(ILocationBalanceFacade locationBalanceFacade, Dictionary<string, ITowerService> towerServices)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(TowersServices)}]: ");
            m_LocationBalanceFacade = locationBalanceFacade;
            m_TowerServices = towerServices;
        }
        
        public async UniTask Preload()
        {
            var toPreloadTasks = new List<UniTask>();
            foreach (var service in m_TowerServices.Values)
            {
                var task = service.Preload();
                toPreloadTasks.Add(task);
            }

            await UniTask.WhenAll(toPreloadTasks);
        }

        public void Init()
        {
            foreach (var service in m_TowerServices.Values)
            {
                service.Init(m_LocationBalanceFacade);
            }
        }
        
        public Result<ITowerFactory> GetFactory(string name)
        {
            if (m_TowerServices.TryGetValue(name, out var service))
            {
                return Result<ITowerFactory>.Success(service.GetFactory());
            }
            
            return Result<ITowerFactory>.Fail();
        }
    }
}