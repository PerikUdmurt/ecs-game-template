using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace Code.UI.Develop.Debugger
{
    [UsedImplicitly]
    public class UIDebuggerController : UIScreenController<UIDebuggerView>
    {
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnCloseClick
                .Subscribe(_ => OnClick())
                .AddTo(disposables);
                
            return UniTask.CompletedTask;
        }

        private void OnClick()
        {
            HideView().Forget();
        }
    }
}
