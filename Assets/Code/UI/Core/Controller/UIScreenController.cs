using Cysharp.Threading.Tasks;
using UniRx;

namespace Code.UI.Core.Controller
{
    public abstract class UIScreenController<TView> : BaseUIScreenController<TView>, ISimpleScreenController
        where TView : IUIScreenView
    {
        public TView View => _view;

        private CompositeDisposable _disposables;

        public async UniTask Show()
        {
            _disposables?.Dispose();
            _disposables = new();
            
            await BeforeShow(_disposables);
            
            _view.Show();

            await AfterShow(_disposables);
        }

        public void ShowAndForget() => Show().Forget();

        protected virtual void OnDispose()
        {
        }

        public sealed override void Dispose()
        {
            OnDispose();
            _disposables?.Dispose();
            _disposables = null;
        }

        protected abstract UniTask BeforeShow(CompositeDisposable disposables);

        protected virtual UniTask AfterShow(CompositeDisposable disposables)
        {
            return UniTask.CompletedTask;
        }
    }

    public interface ISimpleScreenController : IUIScreenController
    {
        UniTask Show();
    }
}