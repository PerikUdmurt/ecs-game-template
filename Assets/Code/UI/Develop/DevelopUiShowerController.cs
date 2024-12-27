using Code.UI.Core;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using UniRx;
using Zenject;

namespace Code.UI.Develop
{
    public class DevelopUiShowerController : UIScreenController<DevelopUiShowerView>
    {
        private IUINavigator _uiNavigator;

        [Inject]
        public void SetDependencies(IUINavigator navigator)
        {
            _uiNavigator = navigator;
        }

        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnShowButtonClick
                .Subscribe(_ => _uiNavigator.Show<DevelopUIController>())
                .AddTo(disposables);

            return UniTask.CompletedTask;
        }
    }
}