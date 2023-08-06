using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Gameplay.Persons.PlayerControlled;
using UnityEngine;

namespace Infrastructure.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private Player _currentPlayer;
        
        public CharacterLocation CharacterLocation { get; private set; }
        
        public async UniTask<Player> GetPlayerFromProvider()
        {
            await UniTask.WaitUntil(() => _currentPlayer != null);
            
            return _currentPlayer;
        }
        
        public void SetPlayerToProvider(Player player) => _currentPlayer = player;

        public void SetCharacterLocationToProvider(CharacterLocation characterLocation)
        {
            CharacterLocation = characterLocation;
        }
    }
}