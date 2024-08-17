using Common;
using TowerDefence.Core.Runtime.Config;
using TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class RifleTowerFactory : ITowerFactory
    {
        private readonly ILocationBalanceFacade m_LocationBalanceFacade;
        private readonly RifleTowerView m_RifleTowerAsset;
        private readonly RifleAmmoSpawner m_RifleAmmoSpawner;
        private readonly UpdateMaster m_UpdateMaster;

        public RifleTowerFactory(
            ILocationBalanceFacade locationBalanceFacade,
            RifleTowerView rifleTowerAsset,
            RifleAmmoSpawner rifleAmmoSpawner,
            UpdateMaster updateMaster)
        {
            m_LocationBalanceFacade = locationBalanceFacade;
            m_RifleTowerAsset = rifleTowerAsset;
            m_RifleAmmoSpawner = rifleAmmoSpawner;
            m_UpdateMaster = updateMaster;
        }

        public Result<ITower> Create(int pointId)
        {
            var towerWaypointResult = m_LocationBalanceFacade.GetTowerWaypoint(pointId);
            if (!towerWaypointResult.IsExist)
            {
                return Result<ITower>.Fail();
            }
            
            var view = Object.Instantiate(m_RifleTowerAsset, towerWaypointResult.Object.Position, Quaternion.identity);
            var rifleWeapon = new RifleWeapon(m_RifleAmmoSpawner, view.AmmoAnchorPoint, m_UpdateMaster);
            var rifleTower = new RifleTower(pointId, view, rifleWeapon);
            return Result<ITower>.Success(rifleTower);        
        }
    }
}