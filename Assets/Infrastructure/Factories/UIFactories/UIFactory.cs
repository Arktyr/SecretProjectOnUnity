using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.Loader;
using Infrastructure.CodeBase.Services.InputService.Base;
using Infrastructure.Instatiator;
using Infrastructure.Providers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Infrastructure.Factories.UIFactories
{
    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IAddressableLoader _addressableLoader;
        private readonly IUIProvider _uiProvider;
        private readonly IInputService _inputService;

        public UIFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider,
            IAddressableLoader addressableLoader,
            IUIProvider uiProvider,
            IInputService inputService)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _addressableLoader = addressableLoader;
            _uiProvider = uiProvider;
            _inputService = inputService;
        }

        public async UniTask Create()
        {
            Canvas canvas = await CreateCanvas();
            _uiProvider.SetCanvasToProvider(canvas);

            EventSystem eventSystem = await CreateEventSystem();
            _uiProvider.SetEventSystemToProvider(eventSystem);
            
            FixedJoystick fixedJoystick = await CreateFixedJoystick(canvas);
            _uiProvider.SetFixedJoystickToProvider(fixedJoystick);
            
           _inputService.PlayerMovementInput.SetFixedJoystick(fixedJoystick);
        }


        private async UniTask<Canvas> CreateCanvas()
        {
            Canvas canvasPrefab = await _addressableLoader.LoadComponent<Canvas>
                (_staticDataProvider.AllAssetsAddresses.AllUIAssetsAddresses.CommonUIAddresses.CanvasPrefab);
            
            return _instantiator.InstantiatePrefabForComponent(canvasPrefab);
        }

        private async UniTask<EventSystem> CreateEventSystem()
        {
            EventSystem eventSystemPrefab = await _addressableLoader.LoadComponent<EventSystem>(_staticDataProvider
                .AllAssetsAddresses.AllUIAssetsAddresses.CommonUIAddresses.EventSystemPrefab);

            return _instantiator.InstantiatePrefabForComponent(eventSystemPrefab);
        }
        
        private async UniTask<FixedJoystick> CreateFixedJoystick(Canvas canvas)
        {
            FixedJoystick fixedJoystickPrefab =
                await _addressableLoader.LoadComponent<FixedJoystick>(_staticDataProvider.AllAssetsAddresses
                    .AllUIAssetsAddresses.InputAssetsAddresses.JoyStick);
            
            return _instantiator.InstantiatePrefabForComponent(fixedJoystickPrefab, canvas.transform.root);
        }
    }
}