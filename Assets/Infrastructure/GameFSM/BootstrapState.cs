using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.SceneManagement;

namespace Infrastructure.GameFSM
{
    public class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneSwitcher _sceneSwitcher;

        public BootstrapState(IStateMachine stateMachine, ISceneSwitcher sceneSwitcher)
        {
            _stateMachine = stateMachine;
            _sceneSwitcher = sceneSwitcher;
     
        }

        public void Exit()
        {
            
        }

        public async void Enter()
        {
            await _sceneSwitcher.LoadScene(SceneType.LevelScene);
            
            _stateMachine.Enter<LevelInitializationState>();
        }
    }
}