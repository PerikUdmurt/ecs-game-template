using Code.UI.Core;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Localization
{
    public class ShowLocalizationScreenButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private IUINavigator _uiNavigator;
        private CompositeDisposable _disposable;
        
        [Inject]
        public void Construct(IUINavigator uiNavigator)
        {
            uiNavigator = uiNavigator;
        }

        public void OnEnable()
        {
            _disposable = new CompositeDisposable();
            
            _button
                .OnClickAsObservable()
                .Subscribe((_) => ShowWindow())
                .AddTo(_disposable);
        }

        public void OnDisable()
        {
            _disposable?.Dispose();
        }

        private void ShowWindow()
        {
            _uiNavigator.Show<LocalizationUIController>();
        }
    }
}