using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public static class RifleTowerEnvironment
    {
        public const string Key = "rifle_tower";

        public const string CrossbowSubtype = "rifle_crossbow";
        
        public static List<string> Subtypes { get; } = new List<string>
        {
            CrossbowSubtype,
        };
    }
}