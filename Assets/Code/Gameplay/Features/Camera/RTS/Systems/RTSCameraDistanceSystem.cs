using System;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class RTSCameraDistanceSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        private readonly IGroup<GameEntity> _input;

        public RTSCameraDistanceSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.RTSCamera,
                GameMatcher.RTSCameraTargetDistance,
                GameMatcher.RTSCameraMinDistance,
                GameMatcher.RTSCameraMaxDistance,
                GameMatcher.CameraScrollDelta));

            _input = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input,
                GameMatcher.ScrollWheelAxis)
                .NoneOf(GameMatcher.RightMouseButtonHold));
        }


        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            foreach (GameEntity input in _input)
            {
                SetCameraDistance(camera, input);
            }
        }

        private void SetCameraDistance(GameEntity camera, GameEntity input)
        {
            float newDistance = camera.rTSCameraTargetDistance.Value - input.ScrollWheelAxis * camera.cameraScrollDelta.Value;
            float resultDistance = Math.Clamp(newDistance, camera.rTSCameraMinDistance.Value, camera.rTSCameraMaxDistance.Value);
            camera.ReplaceRTSCameraTargetDistance(resultDistance);
        }
    }
}