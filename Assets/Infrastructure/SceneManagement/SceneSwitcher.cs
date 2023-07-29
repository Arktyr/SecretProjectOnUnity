using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Infrastructure.SceneManagement
{
    public class SceneSwitcher : ISceneSwitcher
    {
        public Scene CurrentScene { get; private set; }
        
        public async UniTask LoadScene(SceneType sceneType)
        {
            
            var loadScene = Addressables.LoadSceneAsync(sceneType.ToString(), 
                LoadSceneMode.Additive);

            await loadScene;
            
            CurrentScene = SceneManager.GetSceneByName(sceneType.ToString());
        }
    }
}