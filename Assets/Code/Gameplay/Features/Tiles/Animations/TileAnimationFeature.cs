using Code.Gameplay.Features.Tiles.Animations.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Tiles.Animations
{
    [UsedImplicitly]
    public class TileAnimationFeature : Feature
    {
        public TileAnimationFeature(ISystemFactory factory)
        {
            Add(factory.Create<TileRotateAnimationSystem>());
        }
    }
}
