using System;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class CalculateCameraRotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;

        public CalculateCameraRotationSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.RTSCamera,
                GameMatcher.RTSCameraTargetRotation,
                GameMatcher.CameraSlope));
        }


        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            {
                SetCameraRotation(camera);
            }
        }

        private void SetCameraRotation(GameEntity camera)
        {
            float rotY = camera.CameraRotation;
            
            float rotX = camera.CameraSlope;
            
            camera.ReplaceRTSCameraTargetRotation(new Vector3(rotX, rotY, 0));
        }
    }
}