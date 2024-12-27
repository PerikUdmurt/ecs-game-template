using System.Collections.Generic;
using Code.Infrastructures.View.Factory;
using Entitas;

namespace Code.Infrastructures.View.Systems
{
    public class BindViewFromPathEntitySystem : IExecuteSystem
    {
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IGroup<GameEntity> _entities;
        private List<GameEntity> _buffer = new(32);

        public BindViewFromPathEntitySystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(
                    GameMatcher.View,
                    GameMatcher.AssetIsLoading));
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
