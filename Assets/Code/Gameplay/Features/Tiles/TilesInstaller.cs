using Code.Gameplay.Features.Tiles.Animations;
using Code.Gameplay.Features.Tiles.Systems;
using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Tiles
{
    [UsedImplicitly]
    public class TilesInstaller : Installer<TilesInstaller> 
    {
        public override void InstallBindings()
        {
            TileAnimationsInstaller.Install(Container);

            Container
                .Bind<IEmptyTileViewFactory>()
                .To<IEmptyTileFactory>()
                .AsCached();
        }
    }
}
