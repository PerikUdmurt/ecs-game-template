using UnityEngine;
using UnityEngine.Localization;

namespace Code.Gameplay.Features.Tiles.Configs
{
    [CreateAssetMenu(fileName = "TileConfig", menuName = "Configs/Tiles/Tile Config")]
    public class TileConfig : ScriptableObject
    {
        public LocalizedString tileName;
        public LocalizedString tileDescription;
        public ETilePieceType[] tilePieces = new ETilePieceType[6];
    }
}