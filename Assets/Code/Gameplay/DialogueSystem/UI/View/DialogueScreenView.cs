using System;
using System.Threading;
using Code.Common.Extensions;
using Code.UI.Core;
using Cysharp.Threading.Tasks;
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
        [SerializeField] private ScrollRect _scrollbar;
        [SerializeField] private float _lerpSpeed;
        
        public IObservable<Unit> OnClearButtonClicked => _clearHistoryButton.OnClickAsObservable();
        public IObservable<Unit> ShowHistoryButtonClicked => _showHistoryButton.OnClickAsObservable();
        public IObservable<Unit> OnSkipClicked => _skipZone.OnClickAsObservable();
        public Transform BlockContainer => _blockContainer;

        public void SetScrollbarValue(float value) =>
            SwapScrollbar(value).Forget();

        private async UniTask SwapScrollbar(float value)
        {
            while (!Mathf.Approximately(_scrollbar.normalizedPosition.y, value) 
                   || destroyCancellationToken.IsCancellationRequested)
            {
                await UniTask.Yield(cancellationToken: destroyCancellationToken);
                _scrollbar.normalizedPosition.SetY(Mathf.Lerp(_scrollbar.normalizedPosition.y, value, _lerpSpeed));
            }
        }
    }
}
