using Code.Services.InputServices;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Systems
{
    [UsedImplicitly]
    public class MouseScrollWheelInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public MouseScrollWheelInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceScrollWheelAxis(_inputService.GetWheelScrollAxis());
            }
        }
    }
}