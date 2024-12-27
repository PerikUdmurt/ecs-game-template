using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Entitas;

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
            return entity.hasSkipTimerNode;
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
        }
    }
}
