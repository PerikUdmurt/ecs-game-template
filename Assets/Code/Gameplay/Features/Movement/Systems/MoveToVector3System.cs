using Code.Infrastructures.Time;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [UsedImplicitly]
    public class MoveToVector3System : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _movers;

        public MoveToVector3System(GameContext gameContext ,ITimeService timeService)
        {
            _timeService = timeService;
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Moving));
        }

        public void Execute()
        {
            foreach (var entity in _movers)
            {
                entity.ReplaceWorldPosition(Vector3.Lerp(entity.WorldPosition, entity.MoveTargetPosition, entity.Speed));
            }
        }
    }
}