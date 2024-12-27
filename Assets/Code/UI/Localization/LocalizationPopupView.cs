using System;
using Code.Gameplay.DialogueSystem.UI.View;
using Code.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Localization
{
    public class LocalizationPopupView : UIScreenView
    {
        [SerializeField] private MyButton _closeButton;
        [SerializeField] private MyButton _closeZone;
        [SerializeField] private MyButton _buttonPrefab;
        [SerializeField] private LayoutGroup _layoutGroup;
    
        public IObservable<Unit> OnCloseClick => _closeButton.OnClick.Merge(_closeZone.OnClick);

        public MyButton CreateButton(string buttonText) =>
            Instantiate<MyButton>(_buttonPrefab, _layoutGroup.transform);
    }
}