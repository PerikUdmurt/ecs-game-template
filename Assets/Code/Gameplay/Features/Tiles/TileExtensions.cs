using Code.Gameplay.Features.Tiles.Configs;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles
{
    public static class TileExtensions
    {
        public static float GetRotationValue(this ETileRotationType tileRotationType)
        {
            return (float)tileRotationType * 60f;
        }
        
        public static Vector2Int[] GetHexNeighbors(this Vector2Int hexCoord, bool isFlatTop)
        {
            if (isFlatTop)
            {
                return new Vector2Int[]
                {
                    new Vector2Int(hexCoord.x + 1, hexCoord.y - 1),     // Верхний правый
                    new Vector2Int(hexCoord.x + 1, hexCoord.y),         // Правый
                    new Vector2Int(hexCoord.x, hexCoord.y + 1),         // Нижний правый
                    new Vector2Int(hexCoord.x - 1, hexCoord.y + 1),     // Нижний левый
                    new Vector2Int(hexCoord.x - 1, hexCoord.y),         // Левый
                    new Vector2Int(hexCoord.x, hexCoord.y - 1)          // Верхний левый
                };
            }
            else
            {
                return new Vector2Int[]
                {
                    new Vector2Int(hexCoord.x, hexCoord.y - 1),         // Левый нижний
                    new Vector2Int(hexCoord.x + 1, hexCoord.y - 1),     // Верхний правый
                    new Vector2Int(hexCoord.x + 1, hexCoord.y),         // Нижний правый
                    new Vector2Int(hexCoord.x, hexCoord.y + 1),         // Нижний
                    new Vector2Int(hexCoord.x - 1, hexCoord.y + 1),     // Нижний левый
                    new Vector2Int(hexCoord.x - 1, hexCoord.y)          // Верхний левый
                };
            }
        }
    }
}