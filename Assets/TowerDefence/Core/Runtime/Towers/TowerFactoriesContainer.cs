using System;
using Common;

namespace TowerDefence.Core.Runtime.Towers
{
    public class TowerFactoriesContainer
    {
        public void Register(string towerName, ITowerFactory factory)
        {
            
        }
        
        public Result<ITower> Create(string towerName, int pointId)
        {
            throw new NotImplementedException();
        }
    }
}