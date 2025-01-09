using System.Collections.Generic;
using Code.NodeBasedSystem.Core.NodeSystemEntities;
using Cysharp.Threading.Tasks;
using Entitas;
using NodeBasedSystem.Nodes;
using UnityEngine;

namespace Code.NodeBasedSystem.Systems
{
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
                && entity.Node != ENodeType.Choices;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (NodeSystemEntity entity in entities)
            {
                float timeInSeconds = entity.SkipTimerNode;
                SendNextNodeRequestAfterTimer(timeInSeconds).Forget();
            }
        }

        private async UniTask SendNextNodeRequestAfterTimer(float seconds)
        {
            await UniTask.WaitForSeconds(seconds);
            Debug.LogWarning("[AutoskipNodeSystem] SendNextNodeRequestAfterTimer called]");
            CreateNodeSystemEntity.NextNodeRequest();
        }
    }

    public class SimpleNodeHandlingSystem : ReactiveSystem<NodeSystemEntity>
    {
        public SimpleNodeHandlingSystem(NodeSystemContext context) : 
            base(context)
        {
        }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
