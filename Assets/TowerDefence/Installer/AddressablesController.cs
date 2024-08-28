using TowerDefence.Core.Runtime.AddressablesSystem;

namespace TowerDefence.Installer
{
    public class AddressablesController
    {
        public AddressablesService AddressablesService { get; }

        public AddressablesController()
        {
            AddressablesService = new AddressablesService();
        }
    }
}