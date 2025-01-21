using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UniRx;

namespace Code.Gameplay.Test.UI
{
    [UsedImplicitly]
    public class ProgressDebuggerUIController : UIScreenController<ProgressDebuggerUIView>
    {
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            return UniTask.CompletedTask;
        }

        public void SetProgressText(string text) => _view.SetText(text);
    }
}