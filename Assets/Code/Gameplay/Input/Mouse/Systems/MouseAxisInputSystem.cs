using Code.Services.InputServices;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Input.Mouse.Systems
{
    [UsedImplicitly]
    public class MouseAxisInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public MouseAxisInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (GameEntity input in _inputs)
            {
                input.ReplaceMouseAxisInput(new Vector2(
                    _inputService.GetMouseAxisHorizontal(), 
                    _inputService.GetMouseAxisVertical()));
            }
        }
    }
}