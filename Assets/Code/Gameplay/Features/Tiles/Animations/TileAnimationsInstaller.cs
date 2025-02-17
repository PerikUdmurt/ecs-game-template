using Code.Gameplay.Features.Tiles.Animations.Configs;
using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Tiles.Animations
{
    [UsedImplicitly]
    public class TileAnimationsInstaller : Installer<TileAnimationsInstaller>
    {
        private const string COMMON_CONFIG_PATH = "StaticDatas/Tiles/CommonTileAnimationsConfig";
        
        public override void InstallBindings()
        {
            Container.Bind<CommonTileAnimationsConfig>()
                .FromResources(COMMON_CONFIG_PATH)
                .AsSingle();
        }
    }
}