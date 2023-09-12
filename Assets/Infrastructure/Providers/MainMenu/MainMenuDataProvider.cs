using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.Factories;
using UnityEngine;

namespace Infrastructure.Providers.MainMenu
{
    public class MainMenuDataProvider : IMainMenuDataProvider
    {
        private IMainMenuUIFactory _mainMenuUIFactory;
        private IWarmUpper _warmUpper;
        
        public async UniTask<IMainMenuUIFactory> GetMainMenuUIFactory()
        {
            await UniTask.WaitUntil(() => _mainMenuUIFactory != null);
            return _mainMenuUIFactory;
        }

        public void SetMainMenuUIFactory(IMainMenuUIFactory mainMenuUIFactory) => 
            _mainMenuUIFactory = mainMenuUIFactory;
        
        public async UniTask<IWarmUpper> GetMainMenuWarmUpper()
        {
            await UniTask.WaitUntil(() => _warmUpper != null);
            return _warmUpper;
        }

        public void SetMainMenuWarmUpper(IWarmUpper warmUpper) => _warmUpper = warmUpper;
    }
}