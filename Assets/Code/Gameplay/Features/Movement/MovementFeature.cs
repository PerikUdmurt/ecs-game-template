using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Movement
{
    [UsedImplicitly]
    public class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MoveToVector3System>());
            Add(systemFactory.Create<WorldPositionSystem>());
            Add(systemFactory.Create<RotationSystem>());
            Add(systemFactory.Create<ScaleSystem>());
        }
    }
}