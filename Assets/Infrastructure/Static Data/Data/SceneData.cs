using UnityEditor;
using UnityEngine;

namespace Infrastructure.Static_Data.Data
{
    [CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
    public class SceneData : ScriptableObject
    {
        [field:SerializeField] public Vector3 MapSize { get; private set; }
    }
}