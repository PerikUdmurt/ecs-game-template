using Code.Gameplay.Features.Cards.Systems;
using Code.Infrastructures.Factories;

namespace Code.Gameplay.Features.Cards
{
    public class CardFeature : Feature
    {
        public CardFeature(ISystemFactory factory)
        {
            Add(factory.Create<InitializeCardSystem>());
        }
    }
}
