using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.AnyCharacter.Movement;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using UnityEngine;

namespace Infrastructure.Providers
{
    public interface IPlayerProvider
    {
        CharacterLocation CharacterLocation { get; }
        
        UniTask<Player> GetPlayerFromProvider();

        void SetPlayerToProvider(Player player);

        void SetCharacterLocationToProvider(CharacterLocation characterLocation);
    }
}