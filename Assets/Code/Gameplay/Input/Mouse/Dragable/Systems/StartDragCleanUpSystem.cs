using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Dragable.Systems
{
    [UsedImplicitly]
    public class StartDragCleanUpSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _draggings;
        private readonly IGroup<GameEntity> _input;

        public StartDragCleanUpSystem(GameContext game)
        {
            _draggings = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.StartDragging));
        }

        public void Cleanup()
        {
            foreach (GameEntity startDragItem in _draggings.GetEntities())
            {
                startDragItem.isStartDragging = false;
            }
        }
    }
}