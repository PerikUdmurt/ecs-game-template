using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.NodeBasedSystem.DialogueSystem;
using Code.UI.Core;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class BindDialogueControllerSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IUINavigator _uINavigator;

        public BindDialogueControllerSystem(NodeSystemContext context, IUINavigator uINavigator)
            : base(context)
        {
            _uINavigator = uINavigator;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var entity in entities)
            {
                switch (entity.BindDialogueWindow)
                {
                    case EDialogueWindowType.DefaultDialogueWindow:
                        _uINavigator.Perform<DialogueScreenController>(controller => 
                            controller.SetNodePlayer(entity.GraphPlayer));
                        break;
                }
                
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasGraphPlayer
                   && entity.hasBindDialogueWindow;
        }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}