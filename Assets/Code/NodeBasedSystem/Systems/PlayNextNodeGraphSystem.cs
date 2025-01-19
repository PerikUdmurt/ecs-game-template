using System.Collections.Generic;
using Entitas;
using JetBrains.Annotations;

namespace Code.NodeBasedSystem.Systems
{
    [UsedImplicitly]
    public class PlayNextNodeGraphSystem : ReactiveSystem<NodeSystemEntity>
    {
        public PlayNextNodeGraphSystem(NodeSystemContext context) 
            : base(context) { }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasPlayNextGraph
                   && entity.hasGraphPlayer;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity entity in entities)
            {
                entity.GraphPlayer.StartGraph(entity.PlayNextGraph);
            }
        }
    }
}