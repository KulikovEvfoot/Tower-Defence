namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    public class CreateTowerArgs : IGameActionArgs
    {
        public readonly string TowerName;
        public readonly int PointId;

        public CreateTowerArgs(int pointId, string towerName)
        {
            PointId = pointId;
            TowerName = towerName;
        }
    }
}