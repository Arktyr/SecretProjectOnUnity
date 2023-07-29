using Infrastructure.Addressable.AssetsAddresses;
using Infrastructure.Static_Data.Data;

namespace Infrastructure.Providers
{
    public interface IStaticDataProvider
    {
        public PlayerData PlayerData { get;  }
        public SceneData SceneData { get; }
        public UIData UIData { get;  }
        
        public AllAssetsAddresses AllAssetsAddresses { get; }
    }
}