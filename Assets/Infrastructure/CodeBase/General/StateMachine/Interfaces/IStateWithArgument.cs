namespace Infrastructure.CodeBase.General.StateMachine.Interfaces
{
    public interface IStateWithArgument<in TArgs> : IExitableState
    {
        void Enter(TArgs args);
    }
}