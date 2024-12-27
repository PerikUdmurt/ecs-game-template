using Cysharp.Threading.Tasks;
using Zenject;

namespace Code.UI.Core.Controller
{
    public abstract class BaseUIScreenController<TScreenView> : IUIScreenController
        where TScreenView : IUIScreenView
    {
        public EUILayerType UILayer => _layer;

        [Inject] private EUILayerType _layer;
        [Inject] private protected TScreenView _view;

        public async UniTask HideView()
        {
            await BeforeHide();
            _view.Hide();
            await AfterHide();
        }

        public abstract void Dispose();

        protected virtual UniTask BeforeHide()
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask AfterHide()
        {
            return UniTask.CompletedTask;
        }
    }
}