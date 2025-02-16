using Code.Gameplay.Features.Tiles.Factories;
using JetBrains.Annotations;
using Zenject;

namespace Code.Gameplay.Features.Tiles
{
    [UsedImplicitly]
    public class TilesFactoryInstaller : Installer<TilesFactoryInstaller> 
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ITileFactory>()
                .To<TileFactory>()
                .AsCached();
        }
    }
}
