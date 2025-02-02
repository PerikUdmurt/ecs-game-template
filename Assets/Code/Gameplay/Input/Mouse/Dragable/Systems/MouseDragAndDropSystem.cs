using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Input.Mouse.Dragable.Systems
{
    [UsedImplicitly]
    public class MouseDragAndDropSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _draggings;
        private readonly IGroup<GameEntity> _input;

        public MouseDragAndDropSystem(GameContext game)
        {
            _draggings = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dragging,
                    GameMatcher.DragLerp,
                    GameMatcher.WorldPosition));
            
            _input = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }
        
        public void Execute()
        {
            foreach (GameEntity dragableItem in _draggings)
            {
                foreach (GameEntity input in _input)
                {
                    dragableItem.ReplaceWorldPosition(Vector3.Lerp(
                        a: dragableItem.WorldPosition, 
                        b: new Vector3(input.MousePosition.x, input.MousePosition.y), 
                        t: dragableItem.DragLerp));
                }
            }
        }
    }
}
