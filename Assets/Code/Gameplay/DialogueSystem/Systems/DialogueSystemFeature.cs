using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.DialogueSystem.Systems
{
    [UsedImplicitly]
    public class DialogueSystemFeature : Feature
    {
        public DialogueSystemFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<BindDialogueControllerSystem>());
            Add(systemFactory.Create<ShowDialoguePhraseSystem>());
            Add(systemFactory.Create<ShowDialogueChoicesSystem>());
            Add(systemFactory.Create<NextNodeRequestHandlingSystem>());
        }
    }
}