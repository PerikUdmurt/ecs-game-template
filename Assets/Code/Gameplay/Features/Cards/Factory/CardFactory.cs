using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Identifiers;
using Code.Infrastructures.AssetManagement;
using UnityEngine;

namespace Code.Gameplay.Features.Cards.Factory
{
    public class CardFactory
    {
        private readonly IIdentifierService _identifierService;

        public CardFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateCard(ECardType cardType, Vector3 atPosition)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(atPosition)
                .AddSpeed(2)
                .With(entity => entity.isCard = true);
        }
    }
}