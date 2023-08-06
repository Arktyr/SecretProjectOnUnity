using Infrastructure.Addressable.AssetsAddresses;
using Infrastructure.Static_Data.Configs.Enemy;
using Infrastructure.Static_Data.Data;

namespace Infrastructure.Providers
{
    public class StaticDataProvider : IStaticDataProvider
    { 
        public PlayerData PlayerData { get;}
        public LevelData LevelData { get; }
        public UIData UIData { get;  }
        public AllAssetsAddresses AllAssetsAddresses { get; }
        
        public StaticDataProvider(PlayerData playerData, 
            LevelData levelData, 
            UIData uiData,
            AllAssetsAddresses allAssetsAddresses)
        {
            PlayerData = playerData;
            LevelData = levelData;
            UIData = uiData;
            AllAssetsAddresses = allAssetsAddresses;
        }
    }
}
