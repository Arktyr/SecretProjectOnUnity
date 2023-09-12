using Infrastructure.Addressable.WarmUp;
using Infrastructure.CodeBase.Services.UnSubscribe;
using Infrastructure.Factories;
using Infrastructure.Factories.Camera;
using Infrastructure.Factories.UIFactories;
using Infrastructure.Factories.UIFactories.Buttons;
using Infrastructure.Factories.UIFactories.Buttons.Base;
using Infrastructure.Factories.UIFactories.Buttons.Selectable;
using Infrastructure.Factories.UIFactories.Windows;
using Zenject;

namespace Infrastructure.Initialization
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFabrics();
            BindServices();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<DisposableService>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuWarmUpper>().AsSingle();
        }

        private void BindFabrics()
        {
            Container.BindInterfacesAndSelfTo<MainMenuUIFactory>().AsSingle();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle();
            
            Container.Bind<ICommonUIFactory>().To<CommonUIFactory>().AsSingle();
            Container.Bind<IButtonUIFactory>().To<ButtonUIFactory>().AsSingle();
            Container.Bind<ISelectableButtonFactory>().To<SelectableButtonUIFactory>().AsSingle();
            Container.Bind<IBaseButtonUIFactory>().To<BaseButtonUIFactory>().AsSingle();
            Container.Bind<IWindowUIFactory>().To<WindowUIFactory>().AsSingle();
        }
    }
}