using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class AddBenzineEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _resources;

        public AddBenzineEventSystem(NodeSystemContext context, ProgressContext progressContext) 
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
                    var result = resources.Benzine + node.AddBenzine;
                    if (resources.hasMaxBenzine)
                    {
                        if (result >= resources.MaxBenzine)
                        {
                            result = resources.MaxBenzine;
                        }
                    }
                    resources.ReplaceBenzine(result);
                }
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasAddBenzine;
        }
        
        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}