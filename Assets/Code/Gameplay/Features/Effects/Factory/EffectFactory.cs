using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId);
    }

    public class EffectFactory : IEffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
        {
            switch (setup.effectType)
            {
                case EEffectType.Unknown:
                    break;
                case EEffectType.Damage:
                    return CreateDamage(producerId, targetId, setup.Value);
                case EEffectType.Fire:
                    return CreateBurningEffect(producerId, targetId, setup.Value);
            }
            
            throw new Exception($"Effect with type {setup.effectType} is not exist");
        }

        private GameEntity CreateBurningEffect(int producerId, int targetId ,int value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isBurningEffect = true)
                .AddEffectValue(value)
                .AddEffectProducerId(producerId)
                .AddEffectTargetId(targetId);
        }

        private GameEntity CreateDamage(int producerId, int targetId ,int value)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isEffect = true)
                .With(x => x.isDamageEffect = true)
                .AddEffectValue(value)
                .AddEffectProducerId(producerId)
                .AddEffectTargetId(targetId);
        }
    }
}