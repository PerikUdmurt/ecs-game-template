using Code.Gameplay.DialogueSystem.UI.View;
using Code.Infrastructures.AssetManagement;
using Code.Infrastructures.Factories;
using Code.Infrastructures.ObjectPool;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UniRx;

namespace Code.Gameplay.DialogueSystem.UI.Controller
{
    [UsedImplicitly]
    public class DialogueScreenController : UIScreenController<DialogueScreenView>
    {
        private readonly IObjectPool<DialogueBlockUIView> _blockPool;
        private readonly IAsyncMonoFactory _factory;

        public DialogueScreenController(
            ObjectPool<DialogueBlockUIView> blockPool, 
            IAsyncMonoFactory factory)
        {
            _blockPool = blockPool;
            _factory = factory;
        }
        
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.ShowHistoryButtonClicked
                .Subscribe(_ => OnShowHistoryClicked())
                .AddTo(disposables);

            return UniTask.CompletedTask;
        }

        private void OnShowHistoryClicked()
        {
            HideView().Forget();
        }

        public async UniTask ShowPhrase(string text)
        {
            DialogueBlockUIView block = await _blockPool.Get();
            block.transform.SetParent(_view.BlockContainer);
            block.SetDialogueText(text);
            Debug.Log(text);
        }

        public async UniTask ShowChoices()
        {
            DialogueChoicesUIView choicesBlock = 
               await _factory.Create<DialogueChoicesUIView>(AssetPath.DialogueBlockUIView);
            
            choicesBlock.transform.SetParent(_view.BlockContainer);
        }
    }
}