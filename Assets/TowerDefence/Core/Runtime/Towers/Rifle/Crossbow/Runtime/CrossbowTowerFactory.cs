using Common;
using Common.Timer.Runtime;
using TowerDefence.Core.Runtime.Entities;
using TowerDefence.Core.Runtime.Scene;
using TowerDefence.Core.Runtime.Towers.Aim;
using TowerDefence.Core.Runtime.Towers.AttackPriority;
using TowerDefence.Core.Runtime.Towers.Reload;
using TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Crossbow.Runtime
{
    public class CrossbowTowerFactory : ITowerFactory
    {
        private readonly GameObject m_Asset;
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly IGameEntities m_GameEntities;
        private readonly IGlobalTimer m_GlobalTimer;
        private readonly UpdateMaster m_UpdateMaster;

        public CrossbowTowerFactory(
            GameObject asset,
            ILocationBalanceFacade locationBalanceFacade,
            IGameEntities gameEntities,
            IGlobalTimer globalTimer,
            UpdateMaster updateMaster)
        {
            m_Asset = asset;
            m_LocationBalanceFacade = locationBalanceFacade;
            m_GameEntities = gameEntities;
            m_GlobalTimer = globalTimer;
            m_UpdateMaster = updateMaster;
        }

        public Result<ITower> Create(int pointId, TowerLevel towerLevel)
        {
            var towerWaypointResult = m_LocationBalanceFacade.GetTowerWaypoint(pointId);
            if (!towerWaypointResult.IsExist)
            {
                return Result<ITower>.Fail();
            }
            
            var go = Object.Instantiate(m_Asset, towerWaypointResult.Object.Position, Quaternion.identity);

            if (!go.TryGetComponent<CrossbowTowerView>(out var view))
            {
                return Result<ITower>.Fail();
            }
            
            view.Init();

            var testAttackPriorityCollection = new TestAttackPriorityCollection<IShotTarget>();
            
            var reloadData = new ReloadData(magazineCapacity: 1, reloadTime: 2f);
            var towerRecharger = new TowerRecharger(reloadData, m_GlobalTimer);
            
            var towerAim = new TowerAim(m_GlobalTimer);
            
            var infoExpert = new CrossbowTowerInfoExpert(reloadData, towerAim, testAttackPriorityCollection);
            
            var crossbowAmmoFactory = new CrossbowAmmoFactory(m_GameEntities, view.CrossbowAmmoTemplate);
            var crossbowAmmoSpawner = new CrossbowAmmoSpawner(crossbowAmmoFactory);
            
            var crossbowWeapon = new CrossbowWeapon(
                crossbowAmmoSpawner,
                view.AmmoAnchorPoint,
                m_UpdateMaster,
                towerRecharger,
                towerAim);
            
            var towerLogic = new CrossbowTowerLogic(
                view.InteractionObject,
                infoExpert,
                crossbowWeapon,
                m_GameEntities);
            
            var rifleTower = new RifleTower(pointId, view, towerLogic); 
            
            //test
            //change when add upgrades
            rifleTower.SetActive(true);
            
            return Result<ITower>.Success(rifleTower);
        }
    }
}