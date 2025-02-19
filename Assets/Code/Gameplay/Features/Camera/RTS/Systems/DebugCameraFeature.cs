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

    [UsedImplicitly]
    public class SetCameraBoundariesByCellGrid : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;
        private readonly IGroup<GameEntity> _grid;
        
        public SetCameraBoundariesByCellGrid(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.MainCamera));
            
            _grid = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Grid,
                GameMatcher.GridSize));
        }
        
        public void Execute()
        {
            foreach (var camera in _camera)
                foreach (var grid in _grid)
                {
                    
                }
            
        }
    }

    [UsedImplicitly]
    public class CameraOutOfBoundariesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _camera;

        public CameraOutOfBoundariesSystem(GameContext gameContext)
        {
            _camera = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera));
        }
        
        public void Execute()
        {
            
        }
    }
}