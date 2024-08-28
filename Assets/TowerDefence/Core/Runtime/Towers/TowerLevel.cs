namespace TowerDefence.Core.Runtime.Towers
{
    public class TowerLevel
    {
        public static TowerLevel Empty => new TowerLevel("empty", tier: 0);
        
        public string Subtype { get; }
        public int Tier { get; }

        public TowerLevel(string subtype, int tier)
        {
            Subtype = subtype;
            Tier = tier;
        }
    }
}