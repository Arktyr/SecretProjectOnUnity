using Cysharp.Threading.Tasks;
using Infrastructure.Addressable.WarmUp;
using UnityEngine;

namespace Infrastructure.Factories.UIFactories.Windows
{
    public interface IWindowUIFactory
    {
        public UniTask WarmUp();
        public UniTask<GameObject> Create(WindowType windowType);
    }
}