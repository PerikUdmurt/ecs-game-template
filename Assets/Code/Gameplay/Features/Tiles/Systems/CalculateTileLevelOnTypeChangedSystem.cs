using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.Gameplay.Features.Tiles.Configs;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Systems
{
    [UsedImplicitly]
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
                GameMatcher.TileRotationType));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(
                GameMatcher.TileType.AddedOrRemoved(),
                GameMatcher.TilePieces.AddedOrRemoved(),
                GameMatcher.TileRotationType.AddedOrRemoved());
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
            StringBuilder str = new("[CalculateTileLevelOnTypeChangedSystem] Recalculated tile level.");

            foreach (GameEntity tile in entities)
            {
                Vector2Int[] tilesPositions = tile.TilePosition.GetHexNeighbors();
                IEnumerable<GameEntity> targetGroup = _tiles.GetEntities()
                    .Where(e => tilesPositions.Contains(e.TilePosition))
                    .Append(tile);

                foreach (GameEntity t in targetGroup)
                {
                    str.AppendLine($"Tile {t.TilePosition}");
                    RecalculateTileLevelForEntity(t, str);
                }

                Debug.Log(str.ToString());
            }
        }

        private void RecalculateTileLevelForEntity(GameEntity entity, StringBuilder str)
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

                ETilePieceType[] neighbourPieces =
                {
                    neighbourTile.tilePieces.Values.Top,
                    neighbourTile.tilePieces.Values.TopRight,
                    neighbourTile.tilePieces.Values.BottomRight,
                    neighbourTile.tilePieces.Values.Bottom,
                    neighbourTile.tilePieces.Values.BottomLeft,
                    neighbourTile.tilePieces.Values.TopLeft,
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

                ETilePieceType neighbourPiece = neighbourPieces[nind];

                int ind = sourceRotationIndex + i;
                if (ind >= pieces.Length)
                    ind -= pieces.Length;

                ETilePieceType sourcePiece = pieces[ind];

                if (neighbourPiece == sourcePiece)
                {
                    level++;
                }

                str.AppendLine(
                    $"{entity.TilePosition} {ind} {sourcePiece} => {neighbourPiece} {nind} {neighbourTile.TilePosition}");
            }

            entity.ReplaceTileLevel(level);
        }
    }
}