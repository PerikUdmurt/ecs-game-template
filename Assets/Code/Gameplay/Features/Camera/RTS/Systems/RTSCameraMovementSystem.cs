using Entitas;
using Extensions;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class RTSCameraTargetMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        private readonly IGroup<GameEntity> _input;

        public RTSCameraTargetMovementSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.RTSCamera,
                GameMatcher.RTSCameraTargetPosition,
                GameMatcher.Transform,
                GameMatcher.CameraMovementLerp,
                GameMatcher.RatioOfCameraMovementAndDistance,
                GameMatcher.CameraRotation,
                GameMatcher.RTSCameraTargetDistance));

            _input = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.RightMouseButtonHold,
                GameMatcher.MouseAxisInput));
        }


        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            foreach (GameEntity input in _input)
            {
                MoveCamera(camera, input);
            }
        }

        private void MoveCamera(GameEntity camera, GameEntity input)
        {
            Quaternion quaternion = Quaternion.Euler(new Vector3(0, camera.CameraRotation, 0));
            Vector3 delta = input.MouseAxisInput.ToX0Y() * camera.RatioOfCameraMovementAndDistance * camera.RTSCameraTargetDistance;
            Vector3 resultDelta = quaternion * delta;
            Vector3 targetPosition = camera.rTSCameraTargetPosition.Value + resultDelta;
            var resultPosition = Vector3.Lerp(camera.rTSCameraTargetPosition.Value, targetPosition, camera.cameraMovementLerp.Value);
            camera.ReplaceRTSCameraTargetPosition(resultPosition);
        }
    }
}