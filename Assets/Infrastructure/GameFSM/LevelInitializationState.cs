using Cysharp.Threading.Tasks;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.CodeBase.Services.Update;
using Infrastructure.Creation;
using Infrastructure.Providers;

namespace Infrastructure.GameFSM
{
    public class LevelInitializationState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly IUpdaterService _updater;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IInputService _inputService;

        public LevelInitializationState(IStateMachine stateMachine, 
            IUpdaterService updater, 
            ILevelDataProvider levelDataProvider,
            IInputService inputService)
        {
            _stateMachine = stateMachine;
            _updater = updater;
            _levelDataProvider = levelDataProvider;
            _inputService = inputService;
        }

        public async void Enter()
        {
            _inputService.Init();
            
            _inputService.InputEnable();

            await SpawnLevelObjects();
            
            _updater.StartTicking();
            
            _stateMachine.Enter<LevelState>();
        }
        
        public void Exit()
        {
        }
        
        private async UniTask SpawnLevelObjects()
        {
            ILevelObjectFactory levelObjectFactory = await _levelDataProvider.GetLevelObjectFactory();

            await levelObjectFactory.CreateAllObjects();
            
            await levelObjectFactory.CreateAllUIObjects();
        }
    }
}