using Code.Gameplay.Features.Cards.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Cards.Systems
{
    public class InitializeCardSystem : IInitializeSystem
    {
        private readonly CardFactory _factory;

        public InitializeCardSystem(CardFactory factory)
        {
            _factory = factory;
        }
        
        public void Initialize()
        {
            _factory.CreateCard(ECardType.Strength, new Vector3());
        }
    }
}
