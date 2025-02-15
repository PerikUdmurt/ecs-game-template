using Code.Gameplay.Features.Camera.RTS.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.RTS
{
    [UsedImplicitly]
    public class RtsCameraFeature : Feature
    {
        public RtsCameraFeature(ISystemFactory factory)
        {
            Add(factory.Create<RTSCameraTargetMovementSystem>());
            Add(factory.Create<RTSCameraDistanceSystem>());
            Add(factory.Create<CameraRotationSystem>());
            Add(factory.Create<CameraSlopeSystem>());
            Add(factory.Create<CalculateCameraRotationSystem>());
            Add(factory.Create<HandleRtsCameraTransformSystem>());
        }
    }
}
