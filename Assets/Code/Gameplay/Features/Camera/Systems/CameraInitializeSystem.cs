using Code.Common.Entity;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.Systems
{
    [UsedImplicitly]
    public class CameraInitializeSystem : IInitializeSystem
    {
        public void Initialize()
        {
            UnityEngine.Camera camera = UnityEngine.Camera.main;

            CreateEntity.Empty()
                .AddCamera(camera)
                .AddTransform(camera.transform)
                .isMainCamera = true;
        }
    }
}