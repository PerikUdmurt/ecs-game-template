using UnityEngine;

namespace Code.Gameplay.Features.Camera.Configs
{
    [CreateAssetMenu(fileName = "CameraConfig", menuName = "Configs/Camera/CameraConfig")]
    public class CameraConfig : ScriptableObject
    {
        public float initialDistance;
        public float maxDistance;
        public float minDistance;
        public Vector3 initialRotation;
        public float movementLerp;
        public float rotationLerp;
        public float zoomDelta;
        public float rotationDelta;
        public float movementDistanceRatio;
        public Vector3 initialPosition;
        [Range(-90,0)] public float maxZoomSlopeAngle;
        [Range(-90,0)] public float minZoomSlopeAngle;
    }
}