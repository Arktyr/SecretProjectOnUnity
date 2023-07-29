namespace Infrastructure.CodeBase.General.StateMachine.Interfaces
{
    public interface IStateWithArgument : IExitableState
    {
        void Enter<TArgs>(TArgs args);
    }
}