using System.Collections.Generic;
using Common;

namespace TowerDefence.Core.Runtime
{
    public class TowerFactoryProvider
    {
        private readonly Dictionary<int, Dictionary<string, ITowerFactory>> m_Factories = new();

        public Result<ITowerFactory> Get(int pointId, string towerId)
        {
            if (m_Factories.TryGetValue(pointId, out var towersMap))
            {
                if (towersMap.TryGetValue(towerId, out var factory))
                {
                    return Result<ITowerFactory>.Success(factory);
                }
            }
            
            return Result<ITowerFactory>.Fail();
        }
    }
}