using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config.External;
using TowerDefence.Core.Runtime.Towers.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Config
{
    public class LocationBalanceFacade : ILocationBalanceFacade
    {
        private readonly Dictionary<string, ITowerConfig> m_TowerSettings = new();

        private readonly ILogger m_Logger;
        private readonly AddressablesService m_AddressablesService;
        private readonly SceneLocationConfig m_SceneLocationConfig;
        private readonly ExternalLocationConfig m_ExternalLocationConfig;
        private readonly ExternalTowersConfig m_ExternalTowersConfig;

        public LocationBalanceFacade(
            AddressablesService addressablesService,
            SceneLocationConfig sceneLocationConfig,
            ExternalLocationConfig externalLocationConfig,
            ExternalTowersConfig externalTowersConfig)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(LocationBalanceFacade)}]:");
            
            m_AddressablesService = addressablesService;
            m_SceneLocationConfig = sceneLocationConfig;
            m_ExternalLocationConfig = externalLocationConfig;
            m_ExternalTowersConfig = externalTowersConfig;
        }

        public async UniTask Preload()
        {
            foreach (var pair in m_ExternalTowersConfig.TowersConfigsAddresses)
            {
                var towerConfigAsset = await m_AddressablesService.LoadAsync<TextAsset>(pair.Value);
                try
                {
                    var towerConfig = JsonConvert.DeserializeObject<BaseTowerConfig>(towerConfigAsset.text);
                    m_TowerSettings.Add(pair.Key, towerConfig);
                }
                catch (Exception e)
                {
                    m_Logger.Log(LogType.Error, e);
                }
            }
        }
        
        public Result<TowerWaypoint> GetTowerWaypoint(int pointId)
        {
            var towerWaypoint = m_SceneLocationConfig.TowerPoints.FirstOrDefault(p => p.PointId == pointId);
            return new Result<TowerWaypoint>(towerWaypoint, isExist: towerWaypoint == null);
        }

        public IEnumerable<int> GetLevelPreset()
        {
            return new[] { 0, 1, 2 };
        }

        public Result<T> GetTowerSetting<T>(string name) where T : class
        {
            if (!m_TowerSettings.TryGetValue(name, out var setting))
            {
                return Result<T>.Fail();
            }

            if (setting is not T casted)
            {
                return Result<T>.Fail();
            }
            
            return Result<T>.Success(casted);
        }

        public IEnumerable<string> GetAvailableTowers()
        {
            return m_TowerSettings.Keys;
        }
    }
}