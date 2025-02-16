using Code.Gameplay.Features.Camera.RTS;
using Code.Gameplay.Features.Camera.RTS.Systems;
using Code.Gameplay.Features.Camera.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera
{
    [UsedImplicitly]
    public class CameraFeature : Feature
    {
        public CameraFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CameraInitializeSystem>());
            Add(systemFactory.Create<RtsCameraFeature>());
            Add(systemFactory.Create<LookToCameraSystem>());
        }
    }
}
