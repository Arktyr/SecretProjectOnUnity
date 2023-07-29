using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine
{
    public interface IPlayerStateMachine
    {
        public PlayerStateType CurrentState { get; }
        
        public PlayerStateType PastState { get; }

        void Enter<TState>() where TState : class, IPlayerState;
        
        void AddState<TState>(TState state) where TState : IExitableState;
    }
}