using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Clickable.Systems
{
    [UsedImplicitly]
    public class ClickCleanUpSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _clickedItems;
        
        public ClickCleanUpSystem(GameContext game)
        {
            _clickedItems = game.GetGroup(GameMatcher.Clicked);
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _clickedItems.GetEntities())
            {
                entity.isClicked = false;
            }
        }
    }
}
