using System;
using Infrastructure.Gameplay.Persons.Common.Abilities;
using Infrastructure.Static_Data.Configs.Player;
using Infrastructure.Static_Data.Data;
using UnityEditor;
using UnityEngine;

namespace Infrastructure.Static_Data.Configs.CustomEditor
{
    [UnityEditor.CustomEditor(typeof(CharacterData))]
    public class CharacterDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            CharacterData characterData = (CharacterData) target;

            foreach (var ability in characterData.Abilities)
            {
                switch (ability)
                {
                    case AbilityName.CharacterTeleportForward:
                    {
                        GUILayout.BeginHorizontal();
                    
                        GUILayout.Label("TeleportConfig");
                    
                        characterData.CharacterTeleportConfig =
                            EditorGUILayout.ObjectField(characterData.CharacterTeleportConfig,
                                typeof(CharacterTeleportConfig),
                                true) as CharacterTeleportConfig;
                    
                        GUILayout.EndHorizontal();
                        break;
                    }
                    case AbilityName.CharacterAOEAttack:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}