using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.RTS.Systems
{
    [UsedImplicitly]
    public class DebugCameraFeature : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        
        public DebugCameraFeature(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera,
                GameMatcher.RTSCameraTargetPosition));
        }
        
        public void Execute()
        {
            foreach (GameEntity camera in _camera)
            {
                Debug.DrawRay(camera.rTSCameraTargetPosition.Value, Vector3.up * 2f, Color.red);
            }
        }
    }
}