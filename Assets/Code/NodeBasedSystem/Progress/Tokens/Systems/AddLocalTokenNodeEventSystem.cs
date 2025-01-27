using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress.Tokens
{
    [UsedImplicitly]
    public class AddLocalTokenNodeEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<NodeSystemEntity> _tokensEntityGroup;

        public AddLocalTokenNodeEventSystem(NodeSystemContext context) : base(context)
        {
            _tokensEntityGroup = context.GetGroup(
                NodeSystemMatcher.AllOf(NodeSystemMatcher.LocalProgressTokenStorage));
        }
        

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasAddLocalProgressToken;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity tokenRequestEntity in entities)
            {
                string token = tokenRequestEntity.AddLocalProgressToken;
                NodeSystemEntity[] tokenStorages = _tokensEntityGroup.GetEntities();

                foreach (var tokenStorage in tokenStorages)
                {
                    if (!tokenStorage.LocalProgressTokenStorage.Contains(token))
                        tokenStorage.LocalProgressTokenStorage.Add(token);
                }
            }
        }
    }
}