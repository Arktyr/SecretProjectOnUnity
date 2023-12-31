using Infrastructure.Addressable.AssetsAddresses;
using Infrastructure.Addressable.Loader;
using Infrastructure.CodeBase.General.StateMachine;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.InputService.Mobile;
using Infrastructure.CodeBase.Services.Overlap;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Factories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Buttons;
using Infrastructure.Factories.UIFactories.Buttons.Base;
using Infrastructure.Factories.UIFactories.Buttons.Selectable;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.GameFSM;
using Infrastructure.Gameplay.Spawner;
using Infrastructure.Gameplay.Timer;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation;
using Infrastructure.Gameplay.UI.Animations.Window;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.Providers.Common;
using Infrastructure.Providers.MainMenu;
using Infrastructure.Providers.Spawner;
using Infrastructure.Providers.Windows;
using Infrastructure.SceneManagement;
using Infrastructure.Static_Data.Data;
using UnityEngine;
using Zenject;
using IInstantiator = Infrastructure.Instatiator.IInstantiator;


namespace Infrastructure.Initialization
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private LevelData levelData;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private UIData _uiData;
        [SerializeField] private AllAssetsAddresses _allAssetsAddresses;
        
        public override void InstallBindings()
        {
            BindServices();
            BindGameMachine();
            BindProviders();
            BindInputService();
        }
        
        private void BindServices()
        {
            Container.Bind<ISceneSwitcher>().To<SceneSwitcher>().AsSingle();
            Container.Bind<IInstantiator>().To<Instantiator>().AsSingle();
            Container.Bind<IAddressableLoader>().To<AddressableLoader>().AsSingle();
            Container.Bind<IOverlapService>().To<OverlapService>().AsSingle();
            Container.Bind<IPlayTimer>().To<PlayTimer>().AsSingle();
            Container.Bind<IScaleAnimation>().To<ScaleAnimation>().AsSingle();
            Container.Bind<IFadeAnimation>().To<FadeAnimation>().AsSingle();
            Container.Bind<IUIAnimation>().To<UIAnimation>().AsSingle();

            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
        }

        private void BindGameMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LevelInitializationState>().AsSingle();
            Container.Bind<LevelState>().AsSingle();
            Container.Bind<MainMenuState>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle()
                .WithArguments(_playerData, levelData, _uiData, _allAssetsAddresses);
            
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IMainMenuDataProvider>().To<MainMenuDataProvider>().AsSingle();
            Container.Bind<IPlayerProvider>().To<PlayerProvider>().AsSingle();
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
            Container.Bind<IWindowUIProvider>().To<WindowUIProvider>().AsSingle();
            Container.Bind<IEnemySpawnerProvider>().To<EnemySpawnerProvider>().AsSingle();
            Container.Bind<ICommonUIProvider>().To<CommonUiProvider>().AsSingle();
        }
        
        private void BindInputService()
        {
            Container.Bind<IInputWatcher>().To<InputWatcher>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IPlayerMovementInput>().To<PlayerMovementInput>().AsSingle();
            Container.Bind<IPlayerCameraZoomInput>().To<PlayerCameraZoomInput>().AsSingle();
        }
    }
}
