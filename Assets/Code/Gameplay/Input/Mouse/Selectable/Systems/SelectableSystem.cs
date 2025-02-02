using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Selectable.Systems
{
    [UsedImplicitly]
    public class DeselectCleanUpSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _deselectedGroup;
        
        public DeselectCleanUpSystem(GameContext game)
        {
            _deselectedGroup = game.GetGroup(GameMatcher.Deselected);
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _deselectedGroup)
            {
                entity.isDeselected = false;
            }
        }
    }
}
