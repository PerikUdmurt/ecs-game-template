using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Cards.Factory
{
    [UsedImplicitly]
    public class CardFactory : ICardFactory
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
                .AddViewPath("Card")
                .With(entity => entity.isCard = true);
        }
    }

    public interface ICardFactory
    {
        GameEntity CreateCard(ECardType cardType, Vector3 atPosition);
    }
}