using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Factories.UIFactories.Buttons
{
    public interface IButtonUIFactory
    {
        public UniTask WarmUp();
        public UniTask<GameObject> Create(ButtonType buttonType, Transform root);
    }
}