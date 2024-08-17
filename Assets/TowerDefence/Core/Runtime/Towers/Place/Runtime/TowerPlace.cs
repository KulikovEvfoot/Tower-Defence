using System;
using Common;
using Cysharp.Threading.Tasks;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TowerDefence.Core.Runtime.Towers.Place.Runtime
{
    public class TowerPlaceFactory : ITowerFactory
    {
        private readonly TowerPlaceView m_TowerPlaceViewAsset;

        public TowerPlaceFactory(TowerPlaceView towerPlaceViewAsset)
        {
            m_TowerPlaceViewAsset = towerPlaceViewAsset;
        }

        public Result<ITower> Create(int pointId)
        {
            Object.Instantiate(m_TowerPlaceViewAsset);
            
            var t = new TowerPlace();
            return Result<ITower>.Success(t);
        }
    }
    
    public class TowerPlaceService : ITowerService
    {
        private readonly TowerPreloader m_TowerPreloader;
        private readonly ILogger m_Logger;
        
        
        private TowerPlaceView m_TowerPlaceViewAsset;
        private TowerPlaceFactory m_TowerPlaceFactory;

        public async UniTask Preload()
        {
            var viewLoadingResult = await m_TowerPreloader.Load<TowerPlaceView>(TowersEnvironment.TowerPlace);
            if (!viewLoadingResult.IsExist)
            {
                m_Logger.Log(LogType.Error, $"Error when loading {nameof(TowerPlaceView)}");
                return;
            }

            m_TowerPlaceViewAsset = viewLoadingResult.Object;
        }

        public void Init()
        {
            m_TowerPlaceFactory = new TowerPlaceFactory(m_TowerPlaceViewAsset);
        }

        public ITowerFactory GetFactory()
        {
            return m_TowerPlaceFactory;
        }
    }

    
    public class TowerPlace : ITower
    {
    
    }
}
