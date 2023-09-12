using Cysharp.Threading.Tasks;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Providers.MainMenu;

namespace Infrastructure.Addressable.WarmUp
{
    public class MainMenuWarmUpper : IWarmUpper
    {
        private readonly IWindowUIFactory _windowUIFactory;
        private readonly ICommonUIFactory _commonUIFactory;
        private readonly ICameraFactory _cameraFactory;
        private readonly IMainMenuDataProvider _mainMenuDataProvider;

        public MainMenuWarmUpper(IWindowUIFactory windowUIFactory, 
            ICommonUIFactory commonUIFactory,
            ICameraFactory cameraFactory,
            IMainMenuDataProvider mainMenuDataProvider)
        {
            _windowUIFactory = windowUIFactory;
            _commonUIFactory = commonUIFactory;
            _cameraFactory = cameraFactory;
            _mainMenuDataProvider = mainMenuDataProvider;
        }


        public async UniTask WarmUp()
        {
            await _windowUIFactory.WarmUp();
            await _commonUIFactory.WarmUp(); 
            await _cameraFactory.WarmUp();
        }

        public void Initialize() => _mainMenuDataProvider.SetMainMenuWarmUpper(this);
    }
}