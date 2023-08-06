using Infrastructure.Gameplay;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Abilities;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;

namespace Infrastructure.Factories.PlayerFactories
{
    public interface IPlayerStateMachineFactory
    {
        IPlayerStateMachine Construct(CharacterAnimator characterAnimator,
            ICharacterMovement characterMovement);
    }
}