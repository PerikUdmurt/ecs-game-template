using Code.Common;
using Code.UI.Core;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Develop
{
    public class DevelopUIView : UIScreenView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _buttonPrefab;
        [SerializeField] private LayoutGroup _buttonGroup;
        [SerializeField] private TMP_InputField _inputField;

        private List<Button> _instantiatedButtons = new();

        public IObservable<Unit> OnCloseClick => _closeButton.OnClickAsObservable();
        public string InputFieldData { get => _inputField.text; }

        public Button CreateButton(string label)
        {
            Button button = Instantiate(_buttonPrefab, _buttonGroup.transform);
            var buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = label;
            _instantiatedButtons.Add(button);
            button.gameObject.SetActive(true);
            return button;
        }

        public void ReleaseAllButtons()
        {
            for (int i = 0; _instantiatedButtons.Count > i; i++)
            {
                Destroy(_instantiatedButtons[i].gameObject);
            }

            _instantiatedButtons?.Clear();
        }
    }
}