using System;
using System.Collections.Generic;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class CharacterWatcher : ICharacterWatcher, IDisposable
    {
        private readonly List<IDamageNotifier> _characters = new();
        public IReadOnlyList<IDamageNotifier> Characters => _characters;

        private ICollisionWatcher _collisionWatcher;

        private CharacterType _controlCharacterType;

        public void Construct(ICollisionWatcher collisionWatcher, CharacterType characterType)
        {
            _collisionWatcher = collisionWatcher;
            _controlCharacterType = characterType;

            SubscribeToEvents();
        }

        private void AddCharacters(Collider collider)
        {
            if (collider.TryGetComponent(out IDamageNotifier character))
            {
                if (character.CharacterType == _controlCharacterType) {_characters.Add(character);}
            }
        }

        private void RemoveCharactersOnExit(Collider collider)
        {
            if (collider.TryGetComponent(out IDamageNotifier character))
            {
               if (character.CharacterType == _controlCharacterType) _characters.Remove(character);
            }
        }

        public void RemoveDeadCharacters()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                if (_characters[i] == null)
                    _characters.Remove(_characters[i]);
            }
        }

        private void SubscribeToEvents()
        {
            _collisionWatcher.TriggerEntered += AddCharacters;
            _collisionWatcher.TriggerExited += RemoveCharactersOnExit;
        }

        private void UnsubscribeToEvents()
        {
            _collisionWatcher.TriggerEntered -= AddCharacters;
            _collisionWatcher.TriggerExited -= RemoveCharactersOnExit;
        }
        
        public void Dispose() => UnsubscribeToEvents();
    }
}