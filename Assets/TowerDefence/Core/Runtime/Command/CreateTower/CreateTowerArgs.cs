namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    public class CreateTowerArgs : IGameActionArgs
    {
        public readonly int PointId;
        public readonly string TowerId;

        public CreateTowerArgs(int pointId, string towerId)
        {
            PointId = pointId;
            TowerId = towerId;
        }
    }
}