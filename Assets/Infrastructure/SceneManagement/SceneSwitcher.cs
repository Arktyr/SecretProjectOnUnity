using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class SceneSwitcher : ISceneSwitcher
    {
        public Scene CurrentScene { get; private set; }
        
        public async UniTask LoadScene(SceneType sceneType)
        {
            var loadScene = Addressables.LoadSceneAsync(sceneType.ToString());

            await loadScene;
            
            CurrentScene = SceneManager.GetSceneByName(sceneType.ToString());
        }
    }
}