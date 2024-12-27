using System.Collections.Generic;
using Entitas;

namespace Code.NodeBasedSystem.Progress
{
    public class AddMoneyEventSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IGroup<ProgressEntity> _resources;

        public AddMoneyEventSystem(NodeSystemContext context, ProgressContext progressContext) 
            : base(context)
        {
            _resources = progressContext.GetGroup(
                ProgressMatcher.AllOf(
                    ProgressMatcher.PlayerResources,
                    ProgressMatcher.Money));
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var node in entities)
            {
                foreach (var resources in _resources.GetEntities())
                {
                    var result = resources.Money + node.AddMoney;
                    if (resources.hasMaxMoney)
                    {
                        if (result >= resources.MaxMoney)
                        {
                            result = resources.MaxMoney;
                        }
                    }
                    resources.ReplaceMoney(result);
                }
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasAddMoney;
        }
        
        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}