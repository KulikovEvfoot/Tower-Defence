using System.Collections.Generic;
using Launcher;
using TowerDefence.Installer.Launcher.Stage;
using Zenject;

namespace TowerDefence.Installer.Launcher
{
    /// <summary>
    /// Initialize Game Entities
    /// </summary>
    public class CoreSceneLauncher : IInitializable
    {
        private readonly List<IControlEntity> m_ControlEntities;
        
        public bool IsLaunched { get; private set; }

        [Inject]
        public CoreSceneLauncher(List<IControlEntity> controlEntities)
        {
            m_ControlEntities = controlEntities;
        }
        
        public async void Initialize()
        {
            var launchWizard = new LaunchWizard();
            
            launchWizard.AddControlEntities(m_ControlEntities);
            
            launchWizard
                .AddStage(new LaunchStage(nameof(ConfigsLoadingStage)))
                .AddStage(new LaunchStage(nameof(ServicesInitStage)));

            await launchWizard.Run();

            IsLaunched = true;
        }
    }
}