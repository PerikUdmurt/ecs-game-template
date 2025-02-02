using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Dragable.Systems
{
    [UsedImplicitly]
    public class DroppedCleanUpSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _droppeds;
        private readonly IGroup<GameEntity> _input;

        public DroppedCleanUpSystem(GameContext game)
        {
            _droppeds = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Dropped));
        }

        public void Cleanup()
        {
            foreach (GameEntity droppedItem in _droppeds.GetEntities())
            {
                droppedItem.isDropped = false;
            }
        }
    }
}