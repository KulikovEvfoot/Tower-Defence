using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    //add sell button
    public class CreateTowerView : MonoBehaviour
    {
        public event Action<string> OnButtonClick;

        [SerializeField] private Button m_SelectButton;

        private List<Button> m_CreateTowerButtons = new();
        
        //пока так
        public void AddCreateTowerButton(string towerId)
        {
            var btn = Instantiate(m_SelectButton);
            btn.onClick.AddListener(() => OnButtonClick?.Invoke(towerId));
            m_CreateTowerButtons.Add(btn);
        }

        public void Clear()
        {
            m_CreateTowerButtons.Clear();
        }
    }
}