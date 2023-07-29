namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class Character : ICharacter
    {
        public ICharacterMovement CharacterMovement { get; private set; }
        
        public ICharacterInjuring CharacterInjuring { get; private set; }

        public void Construct(ICharacterMovement characterMovement, ICharacterInjuring characterInjuring)
        {
            CharacterMovement = characterMovement;
            CharacterInjuring = characterInjuring;
        }
    }
}