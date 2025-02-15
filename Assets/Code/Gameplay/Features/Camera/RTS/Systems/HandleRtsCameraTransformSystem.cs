using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class HandleRtsCameraTransformSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;

        public HandleRtsCameraTransformSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.RTSCamera,
                GameMatcher.RTSCameraTargetDistance,
                GameMatcher.RTSCameraTargetPosition,
                GameMatcher.RTSCameraTargetRotation,
                GameMatcher.CameraMovementLerp,
                GameMatcher.Transform));
        }
        
        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            {
                Quaternion quaternion = Quaternion.Euler(camera.RTSCameraTargetRotation);
                Vector3 newCameraPosition = camera.rTSCameraTargetPosition.Value + quaternion * Vector3.forward * camera.rTSCameraTargetDistance.Value;
                camera.Transform.position = Vector3.Lerp(camera.Transform.position, newCameraPosition, 0.9f);
                camera.Transform.LookAt(camera.rTSCameraTargetPosition.Value);
            }
        }
    }
}