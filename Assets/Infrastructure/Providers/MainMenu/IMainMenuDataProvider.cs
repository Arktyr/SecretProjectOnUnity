using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;
using Infrastructure.Creation;
using Infrastructure.Factories;

namespace Infrastructure.Providers.MainMenu
{
    public interface IMainMenuDataProvider
    {
        public UniTask<IMainMenuUIFactory> GetMainMenuUIFactory();
        public void SetMainMenuUIFactory(IMainMenuUIFactory mainMenuUIFactory);
        public UniTask<IWarmUpper> GetMainMenuWarmUpper();
        public void SetMainMenuWarmUpper(IWarmUpper warmUpper);
    }
}