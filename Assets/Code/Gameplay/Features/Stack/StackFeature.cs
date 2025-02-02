using Code.Gameplay.Features.Stack.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Stack
{
    [UsedImplicitly]
    public class StackFeature : Feature
    {
        public StackFeature(ISystemFactory factory)
        {
            Add(factory.Create<CardHandInitializeSystem>());
            Add(factory.Create<CardResetInitializeSystem>());
            Add(factory.Create<CardDeckInitializeSystem>());
        }
    }
}
