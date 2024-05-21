using System;
using TowerDefence.Towers.Rifle.Runtime;
using UnityEngine;

namespace TowerDefence.Starter
{
    public class SimpleGameStarter : MonoBehaviour
    {
        [SerializeField] private RifleTowerView m_RifleTowerView;
        
        private RifleTowerFactory m_RifleTowerFactory;

        private void Start()
        {
            // m_RifleTowerFactory = new RifleTowerFactory(m_RifleTowerView, Vector3.zero);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                m_RifleTowerFactory.Create();
                Debug.Log("Key -> K");
            }
        }
    }
}