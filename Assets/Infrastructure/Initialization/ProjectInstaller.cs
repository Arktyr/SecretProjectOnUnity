using Infrastructure.Addressable.AssetsAddresses;
using Infrastructure.Addressable.Loader;
using Infrastructure.CodeBase.General.StateMachine;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.InputService.Mobile;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.GameFSM;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using Infrastructure.SceneManagement;
using Infrastructure.Static_Data.Data;
using UnityEngine;
using Zenject;
using IInstantiator = Infrastructure.Instatiator.IInstantiator;


namespace Infrastructure.Initialization
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;
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

            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
        }

        private void BindGameMachine()
        {
            Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LevelInitializationState>().AsSingle();
            Container.Bind<LevelState>().AsSingle();
        }

        private void BindProviders()
        {
            Container.Bind<IStaticDataProvider>().To<StaticDataProvider>().AsSingle()
                .WithArguments(_playerData, _sceneData, _uiData, _allAssetsAddresses);
            
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            Container.Bind<IPlayerProvider>().To<PlayerProvider>().AsSingle();
            Container.Bind<IUIProvider>().To<UIProvider>().AsSingle();
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
