using Code.Gameplay.Features.Tiles.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles
{
    public static class TileExtensions
    {
        public static float ToRotationValue(this ETileRotationType tileRotationType)
        {
            return (float)tileRotationType * 60f;
        }
        
        public static Vector2Int[] GetHexNeighbors(this Vector2Int hexCoord)
        {

            return new Vector2Int[]
            {
                GetTopNeighbour(hexCoord),
                GetTopRightNeighbour(hexCoord),
                GetBottomRightNeighbour(hexCoord),
                GetBottomNeighbour(hexCoord),
                GetBottomLeftNeighbour(hexCoord),
                GetTopLeftNeighbour(hexCoord),
            };
        }

        public static Vector2Int GetTopNeighbour(this Vector2Int hexCoord) =>
            new Vector2Int(hexCoord.x + 1, hexCoord.y);

        public static Vector2Int GetBottomNeighbour(this Vector2Int hexCoord) =>
            new Vector2Int(hexCoord.x - 1, hexCoord.y);

        public static Vector2Int GetTopRightNeighbour(this Vector2Int hexCoord)
        {
            return hexCoord.y % 2 == 0 
                ? new Vector2Int(hexCoord.x, hexCoord.y + 1) //Chet
                : new Vector2Int(hexCoord.x + 1, hexCoord.y + 1); // Nechet
        }
        
        public static Vector2Int GetBottomRightNeighbour(this Vector2Int hexCoord)
        {
            return hexCoord.y % 2 == 0 
                ? new Vector2Int(hexCoord.x - 1, hexCoord.y + 1) //Chet
                : new Vector2Int(hexCoord.x, hexCoord.y + 1); // Nechet
        }
        
        public static Vector2Int GetBottomLeftNeighbour(this Vector2Int hexCoord)
        {
            return hexCoord.y % 2 == 0 
                ? new Vector2Int(hexCoord.x - 1, hexCoord.y - 1) //Chet
                : new Vector2Int(hexCoord.x, hexCoord.y - 1); // Nechet
        }
        
        public static Vector2Int GetTopLeftNeighbour(this Vector2Int hexCoord)
        {
            return hexCoord.y % 2 == 0 
                ? new Vector2Int(hexCoord.x, hexCoord.y - 1) //Chet
                : new Vector2Int(hexCoord.x + 1, hexCoord.y - 1); // Nechet
        }
    }
}