using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Tiles.Animations.Configs
{
    [CreateAssetMenu(fileName = "CommonTileAnimationsConfig", menuName = "Configs/Tiles/Animations/CommonTileAnimationsConfig")]
    public class CommonTileAnimationsConfig : ScriptableObject
    {
        public float rotationDuration;
        public Ease rotationEase;
    }
}
