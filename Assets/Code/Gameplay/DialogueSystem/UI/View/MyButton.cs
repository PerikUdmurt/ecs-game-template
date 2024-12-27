using System;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.DialogueSystem.UI.View
{
    public class MyButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buttonText;
        [SerializeField] private Button _button;
        
        public IObservable<Unit> OnClick => _button.OnClickAsObservable();

        public void SetButtonText(string text)
            => _buttonText.text = text;
    }
}