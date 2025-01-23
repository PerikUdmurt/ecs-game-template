using System;
using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.View;
using Code.Infrastructures.AssetManagement;
using Code.Infrastructures.Factories;
using Code.Infrastructures.ObjectPool;
using Code.NodeBasedSystem.DialogueSystem;
using Code.NodeBasedSystem.GraphPlayer;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using SABI;
using UniRx;
using UnityEngine;

namespace Code.Gameplay.DialogueSystem.UI.Controller
{
    [UsedImplicitly]
    public class DialogueScreenController : 
        UIScreenController<DialogueScreenView>,
        INodeBasedDialogueController
    {
        private readonly IObjectPool<DialogueBlockUIView> _blockPool;
        private readonly IAsyncMonoFactory _factory;
        private readonly List<DialogueChoicesUIView> _choicesUIViews; 
        private readonly List<DialogueBlockUIView> _instantiatedBlocks;
        private readonly Dictionary<MyButton, IDisposable> _buttonDisposables;
        
        private IGraphPlayer _graphPlayer;
        
        public DialogueScreenController(
            ObjectPool<DialogueBlockUIView> blockPool, 
            IAsyncMonoFactory factory,
            NodeSystemContext nodeSystemContext)
        {
            _choicesUIViews = new List<DialogueChoicesUIView>();
            _blockPool = blockPool;
            _factory = factory;
            _buttonDisposables = new();
            _instantiatedBlocks = new();
        }
        
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.ShowHistoryButtonClicked
                .Subscribe(_ => OnShowHistoryClicked())
                .AddTo(disposables);
            
            _view.OnSkipClicked
                .Subscribe(_ => OnSkipClicked())
                .AddTo(disposables);
            
            _view.OnClearButtonClicked
                .Subscribe(_ => Clear())
                .AddTo(disposables);

            return UniTask.CompletedTask;
        }

        protected override UniTask AfterHide()
        {
            ClearButtonDisposables();
            return UniTask.CompletedTask;
        }

        private void OnSkipClicked()
        {
            foreach (DialogueBlockUIView block in _instantiatedBlocks)
            {
                block.SkipTypewriterAnimation();
            }
            
            _graphPlayer.PlayNextNode();
        }

        private void OnShowHistoryClicked() =>
            HideView().Forget();
        
        public void SetNodePlayer(IGraphPlayer graphPlayer)
        {
            _graphPlayer = graphPlayer;
        }

        public async UniTask ShowPhrase(string text)
        {
            DialogueBlockUIView block = await _blockPool.Get();
            block.transform.SetParent(_view.BlockContainer);
            block.SetDialogueText(text);
            block.PlayTypewriterAnimation();
            _view.SetScrollbarValue(1);
            _instantiatedBlocks.Add(block);
        }

        public async UniTask ShowChoices(List<NextChoiceData> choicesDatas)
        {
            if (choicesDatas.Count == 0)
                return;

            await CreateChoicesBlock(choicesDatas);
            _view.SetScrollbarValue(1);
        }

        private async UniTask CreateChoicesBlock(List<NextChoiceData> choicesDatas)
        {
            DialogueChoicesUIView choicesBlock = 
                await _factory.Create<DialogueChoicesUIView>(AssetPath.DialogueChoicesUIView);

            foreach (NextChoiceData nextChoicesData in choicesDatas)
            {
                MyButton button = choicesBlock.CreateButton(nextChoicesData.text);
                _buttonDisposables[button] = 
                    button.OnClick.Subscribe(c => OnButtonClick(nextChoicesData));
            }

            choicesBlock.transform.SetParent(_view.BlockContainer);
            _choicesUIViews.Add(choicesBlock);
        }

        private void OnButtonClick(NextChoiceData nextChoicesData)
        {
            ShowPhrase(nextChoicesData.text).Forget();
            _graphPlayer.PlayNode(nextChoicesData.nextNodeId);
            ClearButtonDisposables();
            ClearChoicesBlocks();
        }

        private void ClearButtonDisposables()
        {
            foreach (var buttonDisposable in _buttonDisposables.Values)
                buttonDisposable?.Dispose();
            
            _buttonDisposables.Clear();
        }
        
        private void Clear()
        {
            ReleaseDialogueBlocks();
            ClearChoicesBlocks();
        }

        private void ReleaseDialogueBlocks()
        {
            foreach (DialogueBlockUIView block in _instantiatedBlocks)
            {
                _blockPool.Release(block);
            }

            _instantiatedBlocks.Clear();
        }

        private void ClearChoicesBlocks()
        {
            for (int i = 0; i < _choicesUIViews.Count; i++)
            {
                _choicesUIViews[i].DestroyGameObject();
            }

            _choicesUIViews.Clear();
        }
    }
}