using Code.Infrastructures.Factories;
using Code.UI.Core.Navigator;
using JetBrains.Annotations;

namespace Code.Gameplay.DialogueSystem
{
    [UsedImplicitly]
    public class DialogueSystemFeature : Feature
    {
        public DialogueSystemFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ShowDialoguePhraseSystem>());
        }
    }
}