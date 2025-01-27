using System.Collections.Generic;
using Entitas;

namespace Code.NodeBasedSystem.Progress.Tokens
{
    public class AddProgressTokenNodeEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _tokensEntityGroup;

        public AddProgressTokenNodeEventSystem(NodeSystemContext context, ProgressContext progressContext) : base(context)
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
            return entity.hasAddToken;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity tokenRequestEntity in entities)
            {
                string token = tokenRequestEntity.AddToken;
                ProgressEntity[] tokenStorages = _tokensEntityGroup.GetEntities();

                foreach (var tokenStorage in tokenStorages)
                {
                    if (!tokenStorage.ProgressTokenStorage.Contains(token))
                        tokenStorage.ProgressTokenStorage.Add(token);
                }
            }
        }
    }
}
