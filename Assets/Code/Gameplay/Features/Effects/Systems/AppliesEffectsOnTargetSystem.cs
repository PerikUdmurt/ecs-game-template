using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class AppliesEffectsOnTargetSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IEffectFactory _factory;
        private readonly IGroup<GameEntity> _entities;

        public AppliesEffectsOnTargetSystem(GameContext game, IEffectFactory factory)
        {
            _game = game;
            _factory = factory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EffectSetups,
                    GameMatcher.EffectTargetId));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                foreach (EffectSetup setup in entity.EffectSetups)
                {
                    //_factory.CreateEffect(setup, ProducerId(entity), )
                }
            }
        }

        private static int ProducerId(GameEntity entity)
        {
            return entity.hasEffectProducerId ? entity.EffectProducerId : entity.Id;
        }
    }
}
