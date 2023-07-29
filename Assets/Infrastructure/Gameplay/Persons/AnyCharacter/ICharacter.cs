namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public interface ICharacter
    {
        public ICharacterMovement CharacterMovement { get; } 
            
        public ICharacterInjuring CharacterInjuring { get; }
    }
}