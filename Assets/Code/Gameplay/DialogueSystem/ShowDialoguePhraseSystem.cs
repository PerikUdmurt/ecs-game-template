using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.UI.Core;
using Entitas;
using JetBrains.Annotations;
using UnityEngine.Localization.Tables;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class ShowDialoguePhraseSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IUINavigator _uINavigator;

        public ShowDialoguePhraseSystem(NodeSystemContext context, IUINavigator uINavigator) 
            : base(context)
        {
            _uINavigator = uINavigator;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var entity in entities)
            {
                var text = entity.dialoguePhrase.Value;
                _uINavigator.Show<DialogueScreenController>(controller => controller.ShowPhrase(text));
            }
        }

        protected override bool Filter(NodeSystemEntity entity)
        {
            return entity.hasDialoguePhrase;
        }

        protected override ICollector<NodeSystemEntity> GetTrigger(IContext<NodeSystemEntity> context)
        {
            return context.CreateCollector(NodeSystemMatcher.Playing.Added());
        }
    }
}