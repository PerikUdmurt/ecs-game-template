using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress.Tokens
{
    [UsedImplicitly]
    public class RemoveProgressTokenNodeEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _tokensEntityGroup;

        public RemoveProgressTokenNodeEventSystem(NodeSystemContext context, ProgressContext progressContext) : base(context)
        {
            _tokensEntityGroup = progressContext.GetGroup(
                ProgressMatcher.AllOf(ProgressMatcher.ProgressTokenStorage));
        }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasRemoveToken;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity tokenRequestEntity in entities)
            {
                string token = tokenRequestEntity.RemoveToken;
                ProgressEntity[] tokenStorages = _tokensEntityGroup.GetEntities();

                foreach (var tokenStorage in tokenStorages)
                {
                    if (tokenStorage.ProgressTokenStorage.Contains(token))
                        tokenStorage.ProgressTokenStorage.Remove(token);
                }
            }
        }
    }
}