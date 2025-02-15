using Code.Services.InputServices;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse.Systems
{
    [UsedImplicitly]
    public class MouseButtonInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public MouseButtonInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.isRightMouseButtonDown = _inputService.GetRightMouseButtonDown();
                input.isLeftMouseButtonDown = _inputService.GetLeftMouseButtonDown();
                input.isRightMouseButtonUp = _inputService.GetRightMouseButtonUp();
                input.isLeftMouseButtonUp = _inputService.GetLeftMouseButtonUp();
                input.isRightMouseButtonHold = _inputService.GetRightMouseButtonHold();
                input.isLeftMouseButtonHold = _inputService.GetLeftMouseButtonHold();
                input.isMiddleMouseButtonDown = _inputService.GetMiddleMouseButtonDown();
                input.isMiddleMouseButtonUp = _inputService.GetMiddleMouseButtonUp();
                input.isMiddleMouseButtonHold = _inputService.GetMiddleMouseButtonHold();
            }
        }
    }
}