using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;

namespace Infrastructure.Providers.Windows
{
    public class WindowUIProvider : IWindowUIProvider
    {
        private IWindowLogic _pauseMenuWindow;
        private LoadScreenLogic _loadScreenLogic;
        
        public async UniTask<LoadScreenLogic> GetLoadScreenWindowFromProvider()
        {
            await UniTask.WaitUntil(() => _loadScreenLogic != null);
            
            return _loadScreenLogic;
        }

        public async UniTask<IWindowLogic> GetPauseMenuWindowFromProvider()
        {
            await UniTask.WaitUntil(() => _pauseMenuWindow != null);
            
            return _pauseMenuWindow;
        }

        public void SetLoadScreenWindowToProvider(LoadScreenLogic logic) => _loadScreenLogic = logic;

        public void SetPauseMenuWindowToProvider(IWindowLogic logic) => _pauseMenuWindow = logic;
    }
}