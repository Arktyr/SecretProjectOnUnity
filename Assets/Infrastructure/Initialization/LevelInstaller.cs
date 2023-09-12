using Infrastructure.Addressable.WarmUp.Level;
using Infrastructure.CodeBase.Services.UnSubscribe;
using Infrastructure.Creation;
using Infrastructure.Factories.AbilitiesFactory;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.CharactersFactory;
using Infrastructure.Factories.EnemiesFactory;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Buttons;
using Infrastructure.Factories.UIFactories.Buttons.Base;
using Infrastructure.Factories.UIFactories.Buttons.Selectable;
using Infrastructure.Factories.UIFactories.Gameplay;
using Infrastructure.Factories.UIFactories.Windows;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;
using Infrastructure.Gameplay.Spawner;
using Zenject;

namespace Infrastructure.Initialization
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFabrics();
            BindPlayerStateMachine();
            BindServices();
        }
        
        private void BindServices()
        {
            Container.Bind<IEnemyPool>().To<EnemyPool>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<DisposableService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelWarmUpper>().AsSingle();
        }

        private void BindFabrics()
        {
            Container.BindInterfacesAndSelfTo<LevelObjectFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IPlayerCameraFactory>().To<PlayerCameraFactory>().AsSingle();
            Container.Bind<IPlayerStateMachineFactory>().To<PlayerStateMachineFactory>().AsSingle();
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            
            Container.Bind<ICommonUIFactory>().To<CommonUIFactory>().AsSingle();
            Container.Bind<IGameplayUIFactory>().To<GameplayUIFactory>().AsSingle();
            Container.Bind<IButtonUIFactory>().To<ButtonUIFactory>().AsSingle();
            Container.Bind<ISelectableButtonFactory>().To<SelectableButtonUIFactory>().AsSingle();
            Container.Bind<IBaseButtonUIFactory>().To<BaseButtonUIFactory>().AsSingle();
            Container.Bind<IWindowUIFactory>().To<WindowUIFactory>().AsSingle();
        }

        private void BindPlayerStateMachine()
        {
            Container.Bind<IPlayerStateMachine>().To<PlayerStateMachine>().AsSingle();
            
            Container.Bind<RunState>().AsSingle();
            Container.Bind<IdlingState>().AsSingle();
        }
    }
}