using Infrastructure.CodeBase.General.StateMachine.Interfaces;

namespace Infrastructure.GameFSM
{
    public class LevelState : IState
    {
        private readonly IStateMachine _stateMachine;

        public LevelState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            
        }
    }
}