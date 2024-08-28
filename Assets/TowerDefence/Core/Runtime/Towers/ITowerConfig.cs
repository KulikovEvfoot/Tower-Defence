using System;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface ITowerConfig
    {
        string ViewAddress { get; }
    }

    [Serializable]
    public class BaseTowerConfig : ITowerConfig
    {
        [SerializeField] private Dictionary<string, string> m_Property;
        [SerializeField, JsonProperty("address")] private string m_ViewAddress;


        public string ViewAddress => m_ViewAddress;

    }
}