using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.UI;

namespace Code.UI.Develop
{
    public class DevelopUIController : UIScreenController<DevelopUIView>
    {
        private DevelopHUDModel _hudModel;

        public DevelopUIController(DevelopHUDModel model) 
        {
            _hudModel = model;
        }

        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnCloseClick
                .Subscribe(_ => HideView().Forget())
                .AddTo(disposables);

            foreach (var action in _hudModel.Actions)
            {
                Button button = _view.CreateButton(action.Key);
                
                button
                    .OnClickAsObservable()
                    .Subscribe(_ => action.Value?.Invoke(_view.InputFieldData))
                    .AddTo(disposables);
            }

            return UniTask.CompletedTask;
        }

        protected override UniTask AfterHide()
        {
            _view.ReleaseAllButtons();
            return UniTask.CompletedTask;
        }
    }
}