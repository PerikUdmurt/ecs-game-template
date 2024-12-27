using System;
using Code.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Develop.Debugger
{
    public class UIDebuggerView : UIScreenView
    {   
        [SerializeField] private Button _closeButton;

        public IObservable<Unit> OnCloseClick => _closeButton.OnClickAsObservable();
    }
}