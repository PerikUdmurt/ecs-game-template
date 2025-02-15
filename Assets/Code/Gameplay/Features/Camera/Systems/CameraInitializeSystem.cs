using Code.Common.Entity;
using Code.Gameplay.Features.Camera.Configs;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.Systems
{
    [UsedImplicitly]
    public class CameraInitializeSystem : IInitializeSystem
    {
        private readonly CameraConfig _config;
        public CameraInitializeSystem(CameraConfig config)
        {
            _config = config;
        }
        
        public void Initialize()
        {
            UnityEngine.Camera camera = UnityEngine.Camera.main;

            CreateEntity.Empty()
                .AddCamera(camera)
                .AddRTSCamera(camera)
                .AddTransform(camera.transform)
                .AddCameraRotation(_config.initialRotation.y)
                .AddRTSCameraTargetRotation(_config.initialRotation)
                .AddRTSCameraTargetDistance(_config.initialDistance)
                .AddRTSCameraMaxDistance(_config.maxDistance)
                .AddRTSCameraMinDistance(_config.minDistance)
                .AddCameraScrollDelta(_config.zoomDelta)
                .AddRTSCameraTargetPosition(_config.initialPosition)
                .AddCameraMovementLerp(_config.movementLerp)
                .AddCameraRotationLerp(_config.rotationLerp)
                .AddCameraRotationDelta(_config.rotationDelta)
                .AddRatioOfCameraMovementAndDistance(_config.movementDistanceRatio)
                .AddMaxZoomSlope(_config.maxZoomSlopeAngle)
                .AddMinZoomSlope(_config.minZoomSlopeAngle)
                .isMainCamera = true;
        }
    }
}