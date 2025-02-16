using System;
using Code.Gameplay.Features.Tiles.Configs;

namespace Code.Gameplay.Features.Tiles.Datas
{
    [Serializable]
    public class TilePiecesData
    {
        public ETilePieceType Top;
        public ETilePieceType TopRight;
        public ETilePieceType BottomRight;
        public ETilePieceType Bottom;
        public ETilePieceType BottomLeft;
        public ETilePieceType TopLeft;
    }
}
