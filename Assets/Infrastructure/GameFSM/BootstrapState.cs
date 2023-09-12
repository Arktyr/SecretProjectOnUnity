using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Providers.Windows;
using Infrastructure.SceneManagement;
using UnityEngine;

namespace Infrastructure.GameFSM
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneSwitcher _sceneSwitcher;

        public BootstrapState(IStateMachine stateMachine,
            ISceneSwitcher sceneSwitcher)
        {
            _stateMachine = stateMachine;
            _sceneSwitcher = sceneSwitcher;
        }

        public void Exit()
        {
            
        }

        public async void Enter()
        {
            await _sceneSwitcher.LoadScene(SceneType.MainMenu);

            Application.targetFrameRate = 60;
            
            _stateMachine.Enter<MainMenuState>();
        }
    }
}