using Code.Gameplay.Features.Tiles.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Tiles
{
    [UsedImplicitly]
    public class TilesFeature : Feature
    {
        public TilesFeature(ISystemFactory factory)
        {
            Add(factory.Create<InitializeGridSystem>());
            Add(factory.Create<InitializeTilesSystem>());
        }
    }
}
