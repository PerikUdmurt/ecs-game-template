using Code.Services.InputServices;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Input.Mouse.Systems
{
    [UsedImplicitly]
    public class MousePositionInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;
        private readonly IGroup<GameEntity> _cameras;

        public MousePositionInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
            _cameras = game.GetGroup(GameMatcher.Camera);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                foreach (GameEntity camera in _cameras)
                {
                    input.ReplaceMousePosition(_inputService.GetMouseScreenPosition());
                    
                    Vector3 mouseWorldPos = camera.Camera.ScreenToWorldPoint(_inputService.GetMouseScreenPosition());
                    input.ReplaceMouseWorldPosition(mouseWorldPos);
                }
            }
        }
    }
}
