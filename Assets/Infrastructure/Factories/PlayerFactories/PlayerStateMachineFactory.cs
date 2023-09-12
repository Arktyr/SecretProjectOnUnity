using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;

namespace Infrastructure.Factories.PlayerFactories
{
    public class PlayerStateMachineFactory : IPlayerStateMachineFactory
    {
        private readonly IPlayerStateMachine _playerStateMachine;
        
        private readonly RunState _runState;
        private readonly IdlingState _idlingState;
        
        public PlayerStateMachineFactory(RunState runState,
            IdlingState idlingState,
            IPlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
            _runState = runState;
            _idlingState = idlingState;
        }

        public IPlayerStateMachine Construct(CharacterAnimator characterAnimator,
            ICharacterMovement characterMovement)
        {
            _runState.Construct(_playerStateMachine, characterMovement, characterAnimator);
            _playerStateMachine.AddState(_runState);

            _idlingState.Construct(characterAnimator);
            _playerStateMachine.AddState(_idlingState);
            
            _playerStateMachine.Enter<IdlingState>();

            return _playerStateMachine;
        }
    }
}