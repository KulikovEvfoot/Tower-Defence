using System.Linq;
using Common;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.AddressablesSystem;
using TowerDefence.Core.Runtime.Config;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class TowerPreloader
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly AddressablesService m_AddressablesService;
        private readonly ILogger m_Logger;

        public TowerPreloader(
            ILocationBalanceFacade locationBalanceFacade,
            AddressablesService addressablesService,
            ILogger logger)
        {
            m_LocationBalanceFacade = locationBalanceFacade;
            m_AddressablesService = addressablesService;
            m_Logger = logger;
        }

        public async UniTask<Result<T>> Load<T>(string name)
        {
            var towerSettingsResult = m_LocationBalanceFacade.GetTowerSetting<ITowerConfig>(name);
            if (!towerSettingsResult.IsExist)
            {
                m_Logger.Log(LogType.Error, $"Balance doesn't contains when load tower {name}.");
                return Result<T>.Fail();
            }

            var setting = towerSettingsResult.Object;
            var asset = await m_AddressablesService.LoadAsync<GameObject>(setting.ViewAddress);
            if (!asset.TryGetComponent<T>(out var view))
            {
                m_Logger.Log(LogType.Error, $"Item with address {setting.ViewAddress} doesn't contains view component.");
                return Result<T>.Fail();
            }

            return Result<T>.Success(view);
        }
    }
}