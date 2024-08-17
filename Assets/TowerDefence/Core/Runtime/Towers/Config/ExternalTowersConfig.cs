using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Config
{
    [Serializable]
    public class ExternalTowersConfig
    {
        [SerializeField] private Dictionary<string, string> m_TowersConfigsAddresses;

        public IReadOnlyDictionary<string, string> TowersConfigsAddresses => m_TowersConfigsAddresses;

        public ExternalTowersConfig(Dictionary<string, string> towersConfigsAddresses)
        {
            m_TowersConfigsAddresses = towersConfigsAddresses;
        }
    }
}