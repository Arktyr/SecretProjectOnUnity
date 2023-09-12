using Cysharp.Threading.Tasks;

namespace Infrastructure.Gameplay.UI.Windows
{
    public interface IWindowLogic
    {
        public UniTask Enable();
        public UniTask Disable();
    }
}