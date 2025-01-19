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
        private readonly List<DialogueBlockUIView> _instantiatedBlocks;
        private readonly Dictionary<MyButton, IDisposable> _buttonDisposables;
        
        private IGraphPlayer _graphPlayer;
        
        public DialogueScreenController(
            ObjectPool<DialogueBlockUIView> blockPool, 
            IAsyncMonoFactory factory,
            NodeSystemContext nodeSystemContext)
        {
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
                .Subscribe(_ => OnClearButtonClicked())
                .AddTo(disposables);

            return UniTask.CompletedTask;
        }

        protected override UniTask AfterHide()
        {
            ClearButtonDisposables();
            return UniTask.CompletedTask;
        }

        private void OnClearButtonClicked()
        {
            Debug.LogWarning("[DialogueScreenController] OnClearButtonClicked not implemented");
        }

        private void OnSkipClicked() =>
            _graphPlayer.PlayNextNode();

        private void OnShowHistoryClicked()
        {
            HideView().Forget();
        }
        
        public void SetNodePlayer(IGraphPlayer graphPlayer)
        {
            _graphPlayer = graphPlayer;
        }

        public async UniTask ShowPhrase(string text)
        {
            DialogueBlockUIView block = await _blockPool.Get();
            block.transform.SetParent(_view.BlockContainer);
            block.SetDialogueText(text);
            _instantiatedBlocks.Add(block);
        }

        public async UniTask ShowChoices(List<NextChoiceData> choicesDatas)
        {
            if (choicesDatas.Count == 0)
                return;

            await CreateChoicesBlock(choicesDatas);
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
        }

        private void OnButtonClick(NextChoiceData nextChoicesData)
        {
            _graphPlayer.PlayNode(nextChoicesData.nextNodeId);
            ClearButtonDisposables();
        }

        private void ClearButtonDisposables()
        {
            foreach (var buttonDisposable in _buttonDisposables.Values)
                buttonDisposable?.Dispose();
            
            _buttonDisposables.Clear();
        }
    }
}