using System.Collections.Generic;
using Code.Gameplay.Features.Tiles.Configs;
using Code.Gameplay.Features.Tiles.Datas;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles
{
    public class TileTypeComponent : IComponent { public ETileType Value; }
    public class TileLevel : IComponent { public int Value; }
    public class TilePosition : IComponent { public Vector2Int Value; }
    public class TilePieces : IComponent { public TilePiecesData Values; }
    public class TileRotationType : IComponent { public ETileRotationType Value; }
    public class BelongsToTheGrid : IComponent { public Grid Value; }
    public class GridComponent : IComponent { public Grid Value; }
    public class GridSize : IComponent { public Vector2Int Value; }
}