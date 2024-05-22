using System.Collections.Generic;
using Common;
using TowerDefence.Installer.Stage;
using TowerDefence.Launcher;
using Zenject;

namespace TowerDefence.Installer.Launcher
{
    /// <summary>
    /// Initialize Game Entities
    /// </summary>
    public class CoreSceneLauncher : IInitializable
    {
        private readonly List<IControlEntity> m_ControlEntities;
        private readonly ICoroutineRunner m_CoroutineRunner;

        [Inject]
        public CoreSceneLauncher(List<IControlEntity> controlEntities, ICoroutineRunner coroutineRunner)
        {
            m_ControlEntities = controlEntities;
            m_CoroutineRunner = coroutineRunner;
        }
        
        public void Initialize()
        {
            var launchWizard = new LaunchWizard();
            
            launchWizard.AddControlEntities(m_ControlEntities);
            
            launchWizard
                .AddStage(new LaunchStage(nameof(InitStage)));

            m_CoroutineRunner.StartCoroutine(launchWizard.Run());
        }
    }
}