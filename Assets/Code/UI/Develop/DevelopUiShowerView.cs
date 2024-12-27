using Code.UI.Core;
using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Develop
{
    public class DevelopUiShowerView : UIScreenView
    {
        [SerializeField] private Button _showButton;

        public IObservable<Unit> OnShowButtonClick => _showButton.OnClickAsObservable();
    }
}