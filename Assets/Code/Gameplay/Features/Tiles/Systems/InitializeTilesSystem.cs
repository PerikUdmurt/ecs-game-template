using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Tiles.Configs;
using Code.Gameplay.Features.Tiles.Datas;
using Code.Infrastructure.Identifiers;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class InitializeTilesSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _gridGroup;
        
        public InitializeTilesSystem(
            GameContext gameContext,
            IIdentifierService identifierService)
        {
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
                        .AddScale(Vector3.one)
                        .AddBelongsToTheGrid(grid.grid.Value)
                        .AddWorldPosition(grid.Grid.CellToWorld(new Vector3Int(x, y, 0)))
                        .AddRotation(Quaternion.identity)
                        .AddTileRotationType(ETileRotationType.Top)
                        .AddEmptyTileViewPath("EmptyTile")
                        .AddViewPath("TestTile")
                        .With(e => e.isInstantiateWithDisabledView = true)
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
}