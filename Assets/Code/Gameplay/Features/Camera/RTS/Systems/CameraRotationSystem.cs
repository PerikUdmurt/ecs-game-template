using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class CameraRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        private readonly IGroup<GameEntity> _input;

        public CameraRotationSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.RTSCamera,
                GameMatcher.RTSCameraTargetRotation,
                GameMatcher.CameraRotationDelta,
                GameMatcher.CameraRotationLerp));

            _input = gameContext.GetGroup(GameMatcher.AllOf(
                    GameMatcher.Input,
                    GameMatcher.MiddleMouseButtonHold,
                    GameMatcher.MouseAxisInput)
                .NoneOf(GameMatcher.RightMouseButtonHold));
        }


        public void Execute()
        {
            foreach (GameEntity input in _input)
            foreach (GameEntity camera in _camera)
            {
                float targetRotation = camera.RTSCameraTargetRotation.y + input.MouseAxisInput.x * camera.cameraRotationDelta.Value;
                camera.ReplaceCameraRotation(targetRotation);
            }
        }
    }
}