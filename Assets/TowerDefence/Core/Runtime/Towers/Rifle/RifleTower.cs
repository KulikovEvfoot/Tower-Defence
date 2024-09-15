using System;

namespace TowerDefence.Core.Runtime.Towers.Rifle
{
    public class RifleTower : ITower
    {
        private ITowerView m_TowerView;
        private ITowerLogic m_TowerLogic;

        public int PointId { get; }

        private bool m_IsActive;
        
        public RifleTower(int pointId, ITowerView view, ITowerLogic towerLogic)
        {
            PointId = pointId;
            m_TowerView = view;
            m_TowerLogic = towerLogic;
        }

        public void SetActive(bool isActive)
        {
            if (m_IsActive == isActive)
            {
                return;
            }

            m_IsActive = isActive;
            
            m_TowerLogic?.SetActive(m_IsActive);
        }
        
        public void SetLogic(ITowerLogic towerLogic)
        {
            m_TowerLogic.SetActive(false);
            if (m_TowerLogic is IDisposable disposable)
            {
                disposable.Dispose();
            }
            
            m_TowerLogic = towerLogic;
            m_TowerLogic.SetActive(m_IsActive);
        }
    }
}