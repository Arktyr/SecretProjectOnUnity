using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.Persons.AnyCharacter;
using Infrastructure.Static_Data.Data;
using UnityEngine;

namespace Infrastructure.Factories.CharactersFactory
{
    public interface ICharacterFactory
    {
        ICharacter Create(GameObject characterPrefab, CharacterData characterData);
    }
}