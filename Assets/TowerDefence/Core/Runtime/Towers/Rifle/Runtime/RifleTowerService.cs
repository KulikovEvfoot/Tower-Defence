using Common;
using Common.Logger;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleTowerService : ITowerService
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly TowerPreloader m_TowerPreloader;
        private readonly UpdateMaster m_UpdateMaster;
        private readonly ILogger m_Logger;
        
        private RifleTowerView m_TowerViewAsset;
        private RifleTowerFactory m_RifleTowerFactory;

        public RifleTowerService(
            ILocationBalanceFacade locationBalanceFacade,
            TowerPreloader towerPreloader,
            UpdateMaster updateMaster)
        {
            m_Logger = Debug.unityLogger.WithPrefix($"[{nameof(RifleTowerService)}]: ");
            
            m_LocationBalanceFacade = locationBalanceFacade;
            m_TowerPreloader = towerPreloader;
            m_UpdateMaster = updateMaster;
        }

        public async UniTask Preload()
        {
            var viewLoadingResult = await m_TowerPreloader.Load<RifleTowerView>(TowersEnvironment.RifleTower);
            if (!viewLoadingResult.IsExist)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {nameof(RifleTowerView)}");
                return;
            }

            m_TowerViewAsset = viewLoadingResult.Object;
        }

        public void Init()
        {
            var rifleAmmoViewFactory = new RifleAmmoFactory(m_TowerViewAsset.RifleAmmoTemplate);
            var rifleAmmoSpawner = new RifleAmmoSpawner(rifleAmmoViewFactory);
            m_RifleTowerFactory
                = new RifleTowerFactory(m_LocationBalanceFacade, m_TowerViewAsset, rifleAmmoSpawner, m_UpdateMaster);
        }

        public ITowerFactory GetFactory()
        {
            return m_RifleTowerFactory;
        }
    }
}