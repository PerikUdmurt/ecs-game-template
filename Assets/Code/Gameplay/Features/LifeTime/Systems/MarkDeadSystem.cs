using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.LifeTime.Systems
{
    [UsedImplicitly]
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer;

        public MarkDeadSystem(GameContext gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CurrentHp,
                    GameMatcher.MaxHp)
                .NoneOf(GameMatcher.Dead));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.CurrentHp <= 0)
                {
                    entity.isDead = true;
                    entity.isProcessingDeath = true;
                }
            }
        }
    }
}