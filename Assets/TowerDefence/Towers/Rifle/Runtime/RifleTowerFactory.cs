using Common;
using TowerDefence.Core.Runtime;
using TowerDefence.Towers.Rifle.Runtime.Weapon;
using UnityEngine;

namespace TowerDefence.Towers.Rifle.Runtime
{
    public class RifleTowerFactory : ITowerFactory
    {
        private readonly RifleTowerView m_RifleTowerAsset;
        private readonly Vector3 m_Position;
        private readonly Vector3 m_Rotation;
        private readonly IdFactory m_IdFactory;
        private readonly RifleAmmoViewFactory m_RifleAmmoViewFactory;
        private readonly UpdateMaster m_UpdateMaster;

        public RifleTowerFactory(
            RifleTowerView rifleTowerAsset,
            Vector3 position,
            Vector3 rotation,
            IdFactory idFactory,
            RifleAmmoViewFactory rifleAmmoViewFactory,
            UpdateMaster updateMaster)
        {
            m_RifleTowerAsset = rifleTowerAsset;
            m_Position = position;
            m_Rotation = rotation;
            m_IdFactory = idFactory;
            m_RifleAmmoViewFactory = rifleAmmoViewFactory;
            m_UpdateMaster = updateMaster;
        }

        public ITower Create()
        {
            var view = Object.Instantiate(m_RifleTowerAsset, m_Position, Quaternion.Euler(m_Rotation));
            var towerId = m_IdFactory.CreateNext();
            var ammoConfigurator = new RifleAmmoViewConfigurator(view.AmmoAnchorPoint);
            var ammoSpawner = new RifleAmmoSpawner(m_RifleAmmoViewFactory, ammoConfigurator);
            var rifleWeapon = new RifleWeapon(ammoSpawner, view.AmmoAnchorPoint, m_UpdateMaster);
            var rifleTower = new RifleTower(towerId, view, rifleWeapon);
            return rifleTower;
        }
    }
}