using Entitas;

namespace Code.Gameplay.Input.Desktop.DesktopSelectable
{
    public class DesktopSelectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _selectables;
        private readonly IGroup<GameEntity> _currentSelectable;

        public DesktopSelectSystem(GameContext game)
        {
            _selectables = game.GetGroup(GameMatcher.AllOf( 
                    GameMatcher.Selectable,
                    GameMatcher.Transform)
                .NoneOf(GameMatcher.Selected));
        
            _currentSelectable = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Selected, 
                GameMatcher.Selectable));
        
            _inputs = game.GetGroup(GameMatcher.Input);
        }
    
        public void Execute()
        {
            
        }
    }
}
