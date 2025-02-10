using Entitas;

namespace Code.Gameplay.Features.Camera
{
    [Game] public class CameraComponent : IComponent { public UnityEngine.Camera Value; }
    [Game] public class MainCameraComponent : IComponent { }
    [Game] public class LookToCameraComponent : IComponent { }
}