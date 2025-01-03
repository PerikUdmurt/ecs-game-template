using Code.Services.InputServices;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(IInputService inputService, GameContext game)
        {
            this._inputService = inputService;
            _game = game;
            _inputs = game.GetGroup(GameMatcher.Input);
        }

        public void Execute() 
        {
            foreach (var input in _inputs)
            {
                input.ReplaceAxisInput(new Vector2(_inputService.GetAxisHorizontal(), _inputService.GetAxisVertical()));
            }
        }
    }
}