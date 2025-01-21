using Code.Services.InputServices;
using Entitas;

namespace Code.Gameplay.Input.Mouse.Systems
{
    public class MouseInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;


        public MouseInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceMousePosition(_inputService.GetMouseScreenPosition());
            }
        }
    }
}
