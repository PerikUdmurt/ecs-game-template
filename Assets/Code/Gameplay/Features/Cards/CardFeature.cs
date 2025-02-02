using Code.Gameplay.Features.Cards.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Cards
{
    [UsedImplicitly]
    public class CardFeature : Feature
    {
        public CardFeature(ISystemFactory factory)
        {
            Add(factory.Create<InitializeCardSystem>());
        }
    }
}
