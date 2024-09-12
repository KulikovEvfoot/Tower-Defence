using Common;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class CrossbowTowerFactory : ITowerFactory
    {
        private readonly GameObject m_Asset;
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly IGameEntities m_GameEntities;
        private readonly UpdateMaster m_UpdateMaster;

        public CrossbowTowerFactory(
            GameObject asset,
            ILocationBalanceFacade locationBalanceFacade,
            IGameEntities gameEntities,
            UpdateMaster updateMaster)
        {
            m_Asset = asset;
            m_LocationBalanceFacade = locationBalanceFacade;
            m_UpdateMaster = updateMaster;
            m_GameEntities = gameEntities;
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
            
            var crossbowAmmoFactory = new CrossbowAmmoFactory(view.CrossbowAmmoTemplate);
            var crossbowAmmoSpawner = new CrossbowAmmoSpawner(crossbowAmmoFactory);
            var crossbowWeapon = new CrossbowWeapon(crossbowAmmoSpawner, view.AmmoAnchorPoint, m_UpdateMaster);
            var towerLogic = new CrossbowTowerLogic(view.InteractionObject, crossbowWeapon, m_GameEntities);
            var rifleTower = new RifleTower(pointId, view, towerLogic);
            
            return Result<ITower>.Success(rifleTower);
        }
    }
}