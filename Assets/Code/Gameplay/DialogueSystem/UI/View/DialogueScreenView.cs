using System;
using Code.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.DialogueSystem.UI.View
{
    public class DialogueScreenView : UIScreenView
    {
        [SerializeField] private Button _showHistoryButton;
        [SerializeField] private Transform _blockContainer;
        
        public IObservable<Unit> ShowHistoryButtonClicked => _showHistoryButton.OnClickAsObservable();
        public Transform BlockContainer => _blockContainer;
    }
}
