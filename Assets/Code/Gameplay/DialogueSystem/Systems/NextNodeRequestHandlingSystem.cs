using System.Collections.Generic;
using Code.UI.Core;
using Entitas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class NextNodeRequestHandlingSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IUINavigator _uINavigator;

        public NextNodeRequestHandlingSystem(NodeSystemContext context) 
            : base(context) { }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.NextNodeRequest.Added());
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasNextNodeRequest
                   && entity.hasNextNodeRequestGraphId;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            Debug.LogError("[NextNodeRequestHandlingSystem]: Next node request handling is empty]");
        }
    }
}