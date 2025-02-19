using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Features.Tiles.Animations.Configs
{
    [CreateAssetMenu(fileName = "CommonTileAnimationsConfig", menuName = "Configs/Tiles/Animations/CommonTileAnimationsConfig")]
    public class CommonTileAnimationsConfig : ScriptableObject
    {
        [Header("Tile Rotation")]
        public float rotationDuration;
        public Ease rotationEase;
        
        [FormerlySerializedAs("onEmptyTileDuration")] [Header("OnEmptyTileType")]
        public float ScaleTileDuration;
        public Ease onEmptyTileEase;
    }
}
