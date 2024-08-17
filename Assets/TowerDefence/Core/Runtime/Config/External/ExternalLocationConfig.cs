using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Config.External
{
    [Serializable]
    public class ExternalLocationConfig
    {
        [SerializeField] private string m_LevelName;

        public string LevelName => m_LevelName;
    }
}