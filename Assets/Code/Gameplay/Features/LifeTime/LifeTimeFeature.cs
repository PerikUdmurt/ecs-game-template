using Code.Gameplay.Features.LifeTime.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.LifeTime
{
    [UsedImplicitly]
    public class LifeTimeFeature : Feature
    {
        public LifeTimeFeature(ISystemFactory factory)
        {
            Add(factory.Create<MarkDeadSystem>());
        }
    }
}
