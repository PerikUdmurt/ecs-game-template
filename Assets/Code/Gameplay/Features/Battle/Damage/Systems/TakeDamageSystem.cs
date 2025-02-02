using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.LifeTime.Systems
{
    [UsedImplicitly]
    public class TakeDamageSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly GameContext _context;

        public TakeDamageSystem(GameContext gameContext) 
            : base(gameContext)
        {
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.CurrentHp,
                    GameMatcher.MaxHp)
                .NoneOf(GameMatcher.Invincible));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Executing.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBattleActionRequest
                   && entity.hasActionTargetId
                   && entity.hasDamage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity damageAction in entities)
            foreach (GameEntity damagableEntity in _entities.GetEntities())
                if (damageAction.ActionTargetId == damagableEntity.Id)
                    damagableEntity.currentHp.Value -= damagableEntity.Damage;
        }
    }
}