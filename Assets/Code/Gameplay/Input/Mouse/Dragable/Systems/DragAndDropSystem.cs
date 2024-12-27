using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Mouse.Dragable.Systems
{
    public class DragAndDropSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _draggings;
        private readonly IGroup<GameEntity> _input;

        public DragAndDropSystem(GameContext game)
        {
            _draggings = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dragging,
                    GameMatcher.DragLerp,
                    GameMatcher.Transform));
            
            _input = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Input));
        }
        
        public void Execute()
        {
            foreach (GameEntity dragableItem in _draggings)
            {
                foreach (GameEntity input in _input)
                {
                    dragableItem.Transform.position = Vector3.Lerp(
                        a: dragableItem.Transform.position, 
                        b: new Vector3(input.MousePosition.x, input.MousePosition.y), 
                        t: dragableItem.DragLerp);
                }
            }
        }
    }
}
