using Code.Common.LayerMask;
using Code.Gameplay.Common.Physics;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Camera.Systems
{
    [UsedImplicitly]
    public class CameraSelectSystem : IExecuteSystem
    {
        private readonly IPhysics3DService _physicsService;
        private readonly IGroup<GameEntity> _cameras;
        private readonly IGroup<GameEntity> _selectables;
        
        public CameraSelectSystem(GameContext context, IPhysics3DService physicsService)
        {
            _physicsService = physicsService;
            
            _cameras = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera,
                GameMatcher.CameraSelector));
            
            _selectables = context.GetGroup(GameMatcher.Selectable);
        }
        
        public void Execute()
        {
            foreach (var camera in _cameras)
            {
                GameEntity newSelectItem = _physicsService.Raycast(
                    camera.Transform.position, 
                    camera.Transform.forward, 
                    10f,
                    LayerMask.NameToLayer(LayerMasksConstants.Interactive));

                if (!newSelectItem.hasSelectable)
                {
                    return;
                }

                if (!_selectables.ContainsEntity(newSelectItem))
                {
                    
                }
                
                if (newSelectItem != null)
                {
                    
                }
            }
        }
    }
}
