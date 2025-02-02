using Code.Infrastructures.Time;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Movement
{
    [UsedImplicitly]
    public class WorldPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public WorldPositionSystem(GameContext gameContext ,ITimeService timeService)
        {
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (var entity in _movers)
            {
                entity.Transform.position = entity.WorldPosition;
            }
        }
    }
}