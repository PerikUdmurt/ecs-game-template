using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.Features.Camera.Systems
{
    [UsedImplicitly]
    public class LookToCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly IGroup<GameEntity> _cameras;
        
        public LookToCameraSystem(GameContext contexts)
        {
            _cameras = contexts.GetGroup(GameMatcher.AllOf(
                GameMatcher.Camera, 
                GameMatcher.Transform));
            
            _group = contexts.GetGroup(GameMatcher.AllOf(
                GameMatcher.LookToCamera,
                GameMatcher.Transform));
        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _group.GetEntities())
            {
                foreach (GameEntity camera in _cameras.GetEntities())
                {
                    entity.Transform.rotation = camera.Transform.rotation;
                }
            }
        }
    }
}