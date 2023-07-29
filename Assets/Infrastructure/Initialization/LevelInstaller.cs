using Infrastructure.Creation;
using Infrastructure.Factories.AbilitiesFactory;
using Infrastructure.Factories.CharactersFactory;
using Infrastructure.Factories.PlayerFactories;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;
using Zenject;

namespace Infrastructure.Initialization
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFabrics();
            BindPlayerStateMachine();
        }
        
        private void BindFabrics()
        {
            Container.BindInterfacesAndSelfTo<LevelObjectFactory>().AsSingle();
            Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
            Container.Bind<IPlayerCameraFactory>().To<PlayerCameraFactory>().AsSingle();
            Container.Bind<IPlayerStateMachineFactory>().To<PlayerStateMachineFactory>().AsSingle();
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();

            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }

        private void BindPlayerStateMachine()
        {
            Container.Bind<IPlayerStateMachine>().To<PlayerStateMachine>().AsSingle();
            
            Container.Bind<RunState>().AsSingle();
            Container.Bind<IdlingState>().AsSingle();
        }
    }
}