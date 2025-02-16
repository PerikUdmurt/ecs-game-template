using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Gameplay.Features.Tiles.Configs;
using Code.Gameplay.Features.Tiles.Datas;
using Code.Gameplay.Features.Tiles.Factories;
using Code.Infrastructure.Identifiers;
using Entitas;
using Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class InitializeTilesSystem : IInitializeSystem
    {
        private readonly ITileFactory _tileFactory;
        private readonly IGroup<GameEntity> _gridGroup;
        
        public InitializeTilesSystem(
            ITileFactory tileFactory,
            GameContext gameContext,
            IIdentifierService identifierService)
        {
            _tileFactory = tileFactory;
            _gridGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Grid,
                GameMatcher.GridSize));
        }
        
        public void Initialize()
        {
            foreach (var grid in _gridGroup.GetEntities())
            {
                for (int x = 0; x < grid.GridSize.x; x++)
                for (int y = 0; y < grid.GridSize.y; y++)
                {
                    CreateEntity.Empty()
                        .AddTileType(ETileType.Empty)
                        .AddTilePosition(new Vector2Int(x, y))
                        .AddBelongsToTheGrid(grid.grid.Value)
                        .AddWorldPosition(grid.Grid.CellToWorld(new Vector3Int(x, y, 0)))
                        .AddTileRotationType(ETileRotationType.Top)
                        .AddViewPath("EmptyTile")
                        .AddTilePieces(new TilePiecesData()
                        {
                            Top = ETilePieceType.Field,
                            TopRight = ETilePieceType.Field,
                            BottomRight = ETilePieceType.Field,
                            Bottom = ETilePieceType.Mountain,
                            BottomLeft = ETilePieceType.Mountain,
                            TopLeft = ETilePieceType.Mountain
                        });
                }
            }
        }
    }
    
    public class CalculateTileLevelOnTypeChangedSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _tiles;
        
        public CalculateTileLevelOnTypeChangedSystem(GameContext context)
            : base(context)
        {
            _tiles = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.TilePosition, 
                GameMatcher.TileType,
                GameMatcher.TilePieces,
                GameMatcher.TileRotationType,
                GameMatcher.TileLevel));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TileType.AddedOrRemoved());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTileType
                && entity.hasTilePosition
                && entity.hasTileRotationType
                && entity.hasTilePieces
                && entity.hasTileLevel;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity tile in _tiles)
            {
                Vector2Int[] tilesPositions = tile.TilePosition.GetHexNeighbors(false);
                IEnumerable<GameEntity> targetGroup = _tiles.GetEntities()
                    .Where(e => tilesPositions.Contains(e.TilePosition))
                    .Append(tile);

                foreach (GameEntity t in targetGroup)
                {
                    RecalculateTileLevelForEntity(t);
                }
            }
        }

        private void RecalculateTileLevelForEntity(GameEntity entity)
        {
            Vector2Int[] tilesPositions = entity.TilePosition.GetHexNeighbors(false);
            IEnumerable<GameEntity> targetGroup = _tiles.GetEntities()
                .Where(e => tilesPositions.Contains(e.TilePosition));
            
            
            
            entity.ReplaceTileLevel(entity.TileLevel);
        }
    }
}