using Code.Infrastructures.Time;
using Entitas;
using Extensions;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Movement.Systems
{
    [UsedImplicitly]
    public class RotationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public RotationSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Rotation,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (var entity in _movers)
            {
                entity.Transform.rotation = entity.Rotation;
            }
        }
    }
    
    [UsedImplicitly]
    public class ScaleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public ScaleSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Scale,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (var entity in _movers)
            {
                entity.Transform.localScale = entity.Scale;
            }
        }
    }
}