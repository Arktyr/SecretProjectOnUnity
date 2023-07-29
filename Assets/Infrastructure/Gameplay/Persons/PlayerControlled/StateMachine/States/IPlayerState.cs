using Infrastructure.CodeBase.General.StateMachine.Interfaces;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States
{
    public interface IPlayerState : IExitableState
    {
        void Enter();
    }
}