using Cysharp.Threading.Tasks;
using Infrastructure.Gameplay.UI.Windows;
using Infrastructure.Gameplay.UI.Windows.LoadScreen;
using UnityEngine;

namespace Infrastructure.Providers.Windows
{
    public interface IWindowUIProvider
    {
        public UniTask<LoadScreenLogic> GetLoadScreenWindowFromProvider();
        public UniTask<IWindowLogic> GetPauseMenuWindowFromProvider();
        public void SetLoadScreenWindowToProvider(LoadScreenLogic logic);
        public void SetPauseMenuWindowToProvider(IWindowLogic logic);
    }
}