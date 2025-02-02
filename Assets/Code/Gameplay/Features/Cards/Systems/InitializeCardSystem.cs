using Code.Gameplay.Features.Cards.Factory;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Cards.Systems
{
    [UsedImplicitly]
    public class InitializeCardSystem : IInitializeSystem
    {
        private readonly ICardFactory _factory;

        public InitializeCardSystem(ICardFactory factory)
        {
            _factory = factory;
        }
        
        public void Initialize()
        {
            _factory.CreateCard(ECardType.Strength, new Vector3());
            _factory.CreateCard(ECardType.Agility, new Vector3());
        }
    }
}
