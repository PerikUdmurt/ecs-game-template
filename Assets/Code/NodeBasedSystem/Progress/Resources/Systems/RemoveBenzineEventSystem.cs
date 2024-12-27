using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class RemoveBenzineEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _resources;

        public RemoveBenzineEventSystem(NodeSystemContext context, ProgressContext progressContext) 
            : base(context)
        {
            _resources = progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.PlayerResources,
                    ProgressMatcher.Benzine));
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var node in entities)
            {
                foreach (var resources in _resources.GetEntities())
                {
                    var result = resources.Benzine - node.RemoveBenzine;

                    if (result <= 0)
                    {
                        result = 0;
                    }

                    resources.ReplaceBenzine(result);
                }
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasRemoveBenzine;
        }
        
        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}