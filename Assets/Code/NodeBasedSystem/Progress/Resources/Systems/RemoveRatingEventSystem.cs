using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Progress
{
    [UsedImplicitly]
    public class RemoveRatingEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _resources;

        public RemoveRatingEventSystem(NodeSystemContext context, ProgressContext progressContext)
            : base(context)
        {
            _resources = progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.PlayerResources,
                    ProgressMatcher.Rating));
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var node in entities)
            {
                foreach (var resources in _resources.GetEntities())
                {
                    var result = resources.Rating - node.RemoveRating;

                    if (result <= 0)
                    {
                        result = 0;
                    }

                    resources.ReplaceRating(result);
                }
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasRemoveRating;
        }
        
        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}