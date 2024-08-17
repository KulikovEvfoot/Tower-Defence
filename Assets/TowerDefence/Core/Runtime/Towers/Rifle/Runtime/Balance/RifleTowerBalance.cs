using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime.Balance
{
    [Serializable]
    public class RifleTowerBalance : ITowerConfig
    {
        [SerializeField, JsonProperty("address")] private string m_Address;
        
        public string ViewAddress { get; }
    }
}