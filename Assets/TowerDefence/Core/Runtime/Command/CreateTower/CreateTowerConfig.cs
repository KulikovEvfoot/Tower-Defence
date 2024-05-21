using System;
using System.Collections.Generic;

namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    [Serializable]
    public class CreateTowerConfig
    {
        public int PointId;
        public List<string> AvailableTowers;
        public IGameAction CreateTowerAction;
    }
}