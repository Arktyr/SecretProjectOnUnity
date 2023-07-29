namespace Infrastructure.CodeBase.General.StateMachine.Interfaces
{
    public interface IState : IExitableState
    { 
        void Enter();
    }
}