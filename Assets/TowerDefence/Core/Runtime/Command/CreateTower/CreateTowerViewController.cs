using System;
using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    public class CreateTowerViewController : IDisposable
    {
        private readonly CreateTowerViewConfigurator m_ViewConfigurator;
        private readonly CreateTowerView m_View;
        private readonly int m_PointId;
        
        private Dictionary<int, IGameAction> m_Actions = new();
        
        public CreateTowerViewController(CreateTowerView view, CreateTowerConfig config)
        {
            m_ViewConfigurator = new CreateTowerViewConfigurator();
            m_View = view;
            m_PointId = config.PointId;
            
            m_View.OnButtonClick += OnViewButtonClick;

            m_ViewConfigurator.Configure(m_View, config);
        }

        public void Show()
        {
            //sub to tap system and listen tap to world point

            OnViewButtonClick("1");
            // m_View.Show();
        }
        
        public void Hide()
        {
            m_View.Hide();
        }
        
        private void OnViewButtonClick(string towerId)
        {
            m_Actions[m_PointId].Execute(new CreateTowerArgs(m_PointId, towerId));
            
            Hide();
        }

        public void Dispose()
        {
            if (m_View != null)
            {
                m_View.OnButtonClick -= OnViewButtonClick;
            }
        }
    }
}