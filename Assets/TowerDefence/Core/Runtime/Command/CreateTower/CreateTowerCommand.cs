namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    public class CreateTowerCommand : IGameAction
    {
        private readonly TowerFactoryProvider m_TowerFactoryProvider;
     
        public void Execute(IGameActionArgs args)
        {
            if (args is not CreateTowerArgs actionArgs)
            {
                return;
            }

            var factoryResult = m_TowerFactoryProvider.Get(actionArgs.PointId, actionArgs.TowerId);
            if (!factoryResult.IsExist)
            {
                return;
            }
            
            //call any if need (?)
            var tower = factoryResult.Object.Create();
        }
    }
}