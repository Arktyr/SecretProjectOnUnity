using Infrastructure.Addressable.AssetsAddresses;
using Infrastructure.Static_Data.Data;

namespace Infrastructure.Providers
{
    public class StaticDataProvider : IStaticDataProvider
    { 
        public PlayerData PlayerData { get;}
        public SceneData SceneData { get; }
        public UIData UIData { get;  }
        
        public AllAssetsAddresses AllAssetsAddresses { get; }
        
        
        public StaticDataProvider(PlayerData playerData, 
            SceneData sceneData, 
            UIData uiData,
            AllAssetsAddresses allAssetsAddresses)
        {
            PlayerData = playerData;
            SceneData = sceneData;
            UIData = uiData;
            AllAssetsAddresses = allAssetsAddresses;
        }
    }
}
