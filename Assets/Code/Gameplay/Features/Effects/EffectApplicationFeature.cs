using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructures.Factories;

namespace Code.Gameplay.Features.Effects
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory factory)
        {
            Add(factory.Create<AppliesEffectsOnTargetSystem>());
        }
    }
}
