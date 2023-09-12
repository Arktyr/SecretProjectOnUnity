using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.GameFSM;
using UnityEngine;
using Zenject;

namespace Infrastructure.Initialization
{
    public class Bootstrapper : MonoBehaviour, IInitializable
    {
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachine stateMachine,
            BootstrapState bootstrapState, 
            LevelInitializationState levelInitializationState,
            LevelState levelState,
            MainMenuState mainMenuState)
        {
            _stateMachine = stateMachine;
            
            stateMachine.AddState(bootstrapState);
            stateMachine.AddState(levelInitializationState);
            stateMachine.AddState(levelState);
            stateMachine.AddState(mainMenuState);
        }

        public void Initialize() => _stateMachine.Enter<BootstrapState>();
    }
}