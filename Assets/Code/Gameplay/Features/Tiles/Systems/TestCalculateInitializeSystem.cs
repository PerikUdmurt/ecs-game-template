using System.Linq;
using Code.Gameplay.Features.Tiles.Configs;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
    public class TestCalculateInitializeSystem : IInitializeSystem
    {
        private readonly IGroup<GameEntity> _tiles;

        public TestCalculateInitializeSystem(GameContext context)
        {
            _tiles = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.TilePosition,
                GameMatcher.TileType,
                GameMatcher.TilePieces,
                GameMatcher.TileRotationType));
        }

        public void Initialize()
        {
            Debug.Log(_tiles.GetEntities().Length);

            foreach (GameEntity tile in _tiles)
            {
                RecalculateTileLevelForEntity(tile);
            }
        }

        private void RecalculateTileLevelForEntity(GameEntity entity)
        {
            int sourceRotationIndex = (int)entity.TileRotationType;
            Vector2Int[] tilesPositions = entity.TilePosition.GetHexNeighbors();

            ETilePieceType[] pieces =
            {
                entity.tilePieces.Values.Top,
                entity.tilePieces.Values.TopRight,
                entity.tilePieces.Values.BottomRight,
                entity.tilePieces.Values.Bottom,
                entity.tilePieces.Values.BottomLeft,
                entity.tilePieces.Values.TopLeft,
            };

            int level = 0;
            
            for (int i = 0; i < tilesPositions.Length; i++)
            {
                GameEntity neighbourTile = _tiles.GetEntities()
                    .FirstOrDefault(e => e.TilePosition == tilesPositions[i]);

                if (neighbourTile == null)
                    continue;

                int neighbourRotationIndex = (int)neighbourTile.TileRotationType;

                ETilePieceType[] NeighbourPieces =
                {
                    entity.tilePieces.Values.Top,
                    entity.tilePieces.Values.TopRight,
                    entity.tilePieces.Values.BottomRight,
                    entity.tilePieces.Values.Bottom,
                    entity.tilePieces.Values.BottomLeft,
                    entity.tilePieces.Values.TopLeft,
                };

                int nind = neighbourRotationIndex + i + 3;

                if (nind >= 6)
                {
                    nind -= 6;
                    if (nind >= 6)
                    {
                        nind -= 6;
                    }
                }
                
                ETilePieceType neighbourPiece = NeighbourPieces[nind];
                
                int ind = sourceRotationIndex + i;
                if (ind >= pieces.Length)
                    ind -= pieces.Length;
                
                ETilePieceType sourcePiece = pieces[ind];
                
                if (neighbourPiece == sourcePiece)
                {
                    level++;
                }
            }

            entity.ReplaceTileLevel(level);
        }
    }
}