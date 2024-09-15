using System;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Place.Runtime
{
    [Serializable]
    public class TowerPlaceConfig
    {
        [SerializeField, JsonProperty("view_address")] private string m_ViewAddress;

        public string ViewAddress => m_ViewAddress;
    }
}