using TowerDefence.Core.Runtime.AddressablesSystem;
using Zenject;

namespace TowerDefence.Installer
{
    public class AddressablesController
    {
        private readonly AddressablesService m_AddressablesService;

        public AddressablesService AddressablesService => m_AddressablesService;

        [Inject]
        public AddressablesController(AddressablesService addressablesService)
        {
            m_AddressablesService = addressablesService;
        }
    }
}