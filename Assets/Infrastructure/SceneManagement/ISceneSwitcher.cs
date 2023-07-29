using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public interface ISceneSwitcher
    {
        public Scene CurrentScene { get; }

        public UniTask LoadScene(SceneType scene);
    }
}