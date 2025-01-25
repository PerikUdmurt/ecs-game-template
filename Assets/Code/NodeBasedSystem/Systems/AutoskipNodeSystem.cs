using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Entitas;
using JetBrains.Annotations;
using NodeBasedSystem.Nodes;

namespace Code.NodeBasedSystem.Systems
{
    [UsedImplicitly]
    public class AutoskipNodeSystem : ReactiveSystem<NodeSystemEntity>
    {
        public AutoskipNodeSystem(NodeSystemContext context) 
            : base(context) { }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasSkipTimerNode 
                && entity.Node != ENodeType.Choices
                && entity.hasNextNodes
                && entity.hasGraphPlayer;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity entity in entities)
            {
                float timeInSeconds = entity.SkipTimerNode;
                SendNextNodeRequestAfterTimer(timeInSeconds, entity).Forget();
            }
        }

        private async UniTask SendNextNodeRequestAfterTimer(float seconds, NodeSystemEntity node)
        {
            await UniTask.WaitForSeconds(seconds);
            
            if (node.isPlaying)
                node.GraphPlayer.PlayNextNode();
        }
    }
}
