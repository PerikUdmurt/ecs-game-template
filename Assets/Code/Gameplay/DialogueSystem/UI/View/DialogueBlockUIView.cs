using Febucci.UI.Core;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.DialogueSystem.UI.View
{
    public class DialogueBlockUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI authorText;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private TypewriterCore typewriter;
        
        public void SetDialogueText(string text) =>
            dialogueText.text = text;
        
        public void SetAuthorText(string text) =>
            authorText.text = text;

        public void PlayTypewriterAnimation() =>
            typewriter.StartShowingText();
        
        public void SkipTypewriterAnimation() =>
            typewriter.SkipTypewriter();
    }
}
