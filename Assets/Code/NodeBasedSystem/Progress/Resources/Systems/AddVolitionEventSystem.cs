using System.Collections.Generic;
using Entitas;

namespace Code.NodeBasedSystem.Progress
{
    public class AddVolitionEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _resources;

        public AddVolitionEventSystem(NodeSystemContext context, ProgressContext progressContext) 
            : base(context)
        {
            _resources = progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.PlayerResources,
                    ProgressMatcher.Volition));
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var node in entities)
            {
                foreach (var resources in _resources.GetEntities())
                {
                    var result = resources.Volition + node.AddVolition;
                    if (resources.hasMaxVolition)
                    {
                        if (result >= resources.MaxVolition)
                        {
                            result = resources.MaxVolition;
                        }
                    }
                    resources.ReplaceVolition(result);
                }
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasAddVolition;
        }
        
        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}