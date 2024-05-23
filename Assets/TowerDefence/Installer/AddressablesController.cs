using TowerDefence.Core.Runtime.AddressablesSystem;
using Zenject;

namespace TowerDefence.Installer
{
    public class AddressablesController
    {
        public AddressablesService AddressablesService { get; }

        [Inject]
        public AddressablesController()
        {
            AddressablesService = new AddressablesService();
        }
    }
}