using Code.Gameplay.Common.Physics;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Cursor.Systems
{
    [UsedImplicitly]
    public class DetectEntityUnderCursorSystem : IExecuteSystem
    {
        private readonly IPhysics3DService _physicsService;
        private readonly IGroup<GameEntity> _inputGroup;
        private readonly IGroup<GameEntity> _cursorGroup;
        private readonly IGroup<GameEntity> _cameraGroup;
        
        public DetectEntityUnderCursorSystem(GameContext gameContext, IPhysics3DService physicsService)
        {
            _physicsService = physicsService;
            
            _inputGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Input, 
                GameMatcher.MousePosition));
            
            _cursorGroup = gameContext.GetGroup(GameMatcher.Cursor);
            
            _cameraGroup = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera, 
                GameMatcher.MainCamera, 
                GameMatcher.Transform));
        }
        
        public void Execute()
        {
            foreach (var cursor in _cursorGroup)
            foreach (var input in _inputGroup)
            foreach (var camera in _cameraGroup)
            {
                GameEntity entity = _physicsService.ScreenPointToRay(
                    input.MousePosition,
                    LayerMask.GetMask("Interactive"),
                    camera.Camera
                );              
                        
                cursor.ReplaceEntityUnderCursor(entity);
            }
        }
    }
}