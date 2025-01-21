using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.Controller;
using Code.NodeBasedSystem.Core.Datas;
using Code.Services.LocalizationServices;
using Code.UI.Core;
using Cysharp.Threading.Tasks;
using Entitas;
using JetBrains.Annotations;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class ShowDialoguePhraseSystem : ReactiveSystem<NodeSystemEntity>
    {
        private readonly IUINavigator _uINavigator;
        private readonly ILocalizationService _localizationService;

        public ShowDialoguePhraseSystem(NodeSystemContext context, IUINavigator uINavigator, ILocalizationService localizationService)
            : base(context)
        {
            _uINavigator = uINavigator;
            _localizationService = localizationService;
        }

        protected override void Execute(List<NodeSystemEntity> entities)
        {
            foreach (var entity in entities)
            {
                LocalizedStringData data = entity.dialoguePhrase.Value;

                string text = _localizationService.GetLocalizedString(data);
                
                _uINavigator.Show<DialogueScreenController>(controller => 
                    controller.ShowPhrase(text).Forget());
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