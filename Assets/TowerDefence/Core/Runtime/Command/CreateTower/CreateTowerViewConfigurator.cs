namespace TowerDefence.Core.Runtime.Command.CreateTower
{
    public class CreateTowerViewConfigurator
    {
        public void Configure(CreateTowerView view, CreateTowerConfig config)
        {
            view.Clear();
            foreach (var towerName in config.AvailableTowers)
            {
                view.AddCreateTowerButton(towerName);
            }
        }
    }
}