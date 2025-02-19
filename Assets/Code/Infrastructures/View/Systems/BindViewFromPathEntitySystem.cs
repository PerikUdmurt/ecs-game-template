using System.Collections.Generic;
using Code.Infrastructures.View.Factory;
using Entitas;
using JetBrains.Annotations;

namespace Code.Infrastructures.View.Systems
{
    [UsedImplicitly]
    public class BindViewFromPathEntitySystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public BindViewFromPathEntitySystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.AssetIsLoading));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _entityViewFactory.CreateViewForEntity(entity);
            }
        }
    }
}
