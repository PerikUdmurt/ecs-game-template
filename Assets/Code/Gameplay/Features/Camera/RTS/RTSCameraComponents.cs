using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS
{
    [Game] public class RTSCamera : IComponent { public UnityEngine.Camera Value; }
    [Game] public class RTSCameraTargetPosition : IComponent { public Vector3 Value; }
    [Game] public class RTSCameraTargetDistance : IComponent { public float Value; }
    [Game] public class RTSCameraTargetRotation : IComponent { public Vector3 Value; }
    [Game] public class RTSCameraMaxDistance : IComponent { public float Value; }
    [Game] public class RTSCameraMinDistance : IComponent { public float Value; }
    [Game] public class CameraRotationDelta : IComponent { public float Value; }
    [Game] public class CameraMovementDelta : IComponent { public float Value; }
    [Game] public class CameraScrollDelta : IComponent { public float Value; }
    [Game] public class CameraMovementLerp : IComponent { public float Value; }
    [Game] public class CameraRotationLerp : IComponent { public float Value; }
    [Game] public class CameraScrollLerp : IComponent { public float Value; }
    [Game] public class RatioOfCameraMovementAndDistance : IComponent { public float Value; }
    [Game] public class MaxZoomSlope : IComponent { public float Value; }
    [Game] public class MinZoomSlope : IComponent { public float Value; }
    [Game] public class CameraSlope : IComponent { public float Value; }
    [Game] public class CameraRotation : IComponent { public float Value; }
}
