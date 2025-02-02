using Code.Gameplay.Features.LifeTime.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Battle
{
    [UsedImplicitly]
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory factory)
        {
            Add(factory.Create<TakeDamageSystem>());
        }
    }
}
