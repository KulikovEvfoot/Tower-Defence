using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public class TowerFactoryProvider : ITowerFactory
    {
        private readonly Dictionary<string, ITowerFactory> m_ConcreteFactories;

        public TowerFactoryProvider(Dictionary<string, ITowerFactory> concreteFactories)
        {
            m_ConcreteFactories = concreteFactories;
        }

        public Result<ITower> Create(int pointId, TowerLevel towerLevel)
        {
            if (!m_ConcreteFactories.TryGetValue(towerLevel.Subtype, out var factory))
            {
                return Result<ITower>.Fail();
            }

            return factory.Create(pointId, towerLevel);
        }
    }
}