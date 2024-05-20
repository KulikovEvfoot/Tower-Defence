using Common;
using UnityEngine;

namespace TowerDefence.Runtime
{
    public class BulletShotSimulation
    {
        private Vector3 m_Sender;
        private IShotTarget m_Target;
        private Bullet m_Bullet;
    
        private UpdateMaster m_UpdateMaster;
    
        public BulletShotSimulation()
        {
            m_UpdateMaster.OnUpdate += OnUpdate;
        }

        private void OnUpdate()
        {
            //TODO: логика полёта
        }
    }
}