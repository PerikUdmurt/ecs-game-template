using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class CameraSlopeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        
        public CameraSlopeSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.MaxZoomSlope,
                GameMatcher.MinZoomSlope,
                GameMatcher.RTSCameraMaxDistance,
                GameMatcher.RTSCameraMinDistance,
                GameMatcher.RTSCameraTargetDistance));
        }
        
        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            {
                float ratio = (camera.RTSCameraTargetDistance - camera.RTSCameraMinDistance) /
                              (camera.RTSCameraMaxDistance - camera.RTSCameraMinDistance);
                
                float currentSlope = (camera.MaxZoomSlope - camera.MinZoomSlope) * ratio;
                
                camera.ReplaceCameraSlope(currentSlope);
            }
        }
    }
}