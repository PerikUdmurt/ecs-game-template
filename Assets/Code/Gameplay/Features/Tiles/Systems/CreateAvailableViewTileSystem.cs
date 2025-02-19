using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class CreateEmptyViewTileSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _tiles;
        private readonly IEmptyTileViewFactory _tilefactory;
        private readonly List<GameEntity> _buffer = new(32);
        
        public CreateEmptyViewTileSystem(GameContext gameContext, IEmptyTileViewFactory tileFactory)
        {
            _tilefactory = tileFactory;
            
            _tiles = gameContext.GetGroup(GameMatcher.AllOf(
                    GameMatcher.EmptyTileViewPath, 
                    GameMatcher.WorldPosition)
                .NoneOf(
                    GameMatcher.EmptyTileIsLoading));
        }
        
        public void Execute()
        {
            foreach (GameEntity tile in _tiles.GetEntities(_buffer))
            {
                _tilefactory.CreateViewForEntity(tile);
            }
        }
    }
}