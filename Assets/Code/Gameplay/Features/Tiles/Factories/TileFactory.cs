using Code.Gameplay.Features.Tiles.Configs;
using Code.Infrastructures.Factories;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Tiles.Factories
{
    [UsedImplicitly]
    public class TileFactory : ITileFactory
    {
        private readonly IAsyncMonoFactory _factory;
        private readonly IGroup<GameEntity> _gridGroup;
        private readonly IGroup<GameEntity> _tiles;
        
        public TileFactory(IAsyncMonoFactory factory, GameContext gameContext)
        {
            _factory = factory;
            
            _gridGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Grid));
        }

        public void CreateEmptyTileForEntity(GameEntity entity)
        {
            foreach (var gridEntity in _gridGroup.GetEntities())
            {
                
            }
        }

        public void CreateViewForEntity(GameEntity entity, TileConfig tileConfig)
        {
            
        }
    }
}