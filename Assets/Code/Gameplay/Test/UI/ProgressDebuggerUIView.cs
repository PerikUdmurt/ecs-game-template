using Code.UI.Core;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Test.UI
{
    public class ProgressDebuggerUIView : UIScreenView
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void SetText(string text)
            => _text.text = text;
    }
}