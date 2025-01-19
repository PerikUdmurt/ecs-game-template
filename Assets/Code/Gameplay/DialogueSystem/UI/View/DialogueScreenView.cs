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
        [SerializeField] private Button _skipZone;
        [SerializeField] private Button _clearHistoryButton;
        
        public IObservable<Unit> OnClearButtonClicked => _clearHistoryButton.OnClickAsObservable();
        public IObservable<Unit> ShowHistoryButtonClicked => _showHistoryButton.OnClickAsObservable();
        public IObservable<Unit> OnSkipClicked => _skipZone.OnClickAsObservable();
        public Transform BlockContainer => _blockContainer;
    }
}
