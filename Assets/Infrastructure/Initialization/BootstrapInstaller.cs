using UnityEngine;
using Zenject;

namespace Infrastructure.Initialization
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private Bootstrapper _bootstrapper;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrapper>().FromInstance(_bootstrapper).AsSingle();
        }
    }
}