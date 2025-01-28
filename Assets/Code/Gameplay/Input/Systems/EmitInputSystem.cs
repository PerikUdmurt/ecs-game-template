using Code.Services.InputServices;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    [UsedImplicitly]
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(IInputService inputService, GameContext game)
        {
            _inputService = inputService;
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute() 
        {
            foreach (var input in _inputs)
            {
                input.ReplaceAxisInput(new Vector2(
                    _inputService.GetAxisHorizontal(),
                    _inputService.GetAxisVertical()));
            }
        }
    }
}