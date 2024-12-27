using System.Collections.Generic;
using Code.Gameplay.DialogueSystem.UI.View;
using Code.Services.LocalizationServices;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Code.UI.Localization
{
    public class LocalizationUIController : UIScreenController<LocalizationPopupView>
    {
        private readonly ILocalizationService _localizationService;
        private readonly List<MyButton> _buttons;

        public LocalizationUIController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
            _buttons = new List<MyButton>();
        }

        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            _view.OnCloseClick
                .Subscribe(_ => HideView().Forget())
                .AddTo(disposables);

            foreach (ELocaleType localeType in _localizationService.GetAvailableLocale())
            {
                MyButton button = _view.CreateButton(localeType.ToString());
                button.SetButtonText(localeType.ToString());
                
                button.OnClick
                    .Subscribe(_ => _localizationService.SetLocale(localeType))
                    .AddTo(disposables);

                _buttons.Add(button);
            }
            
            return UniTask.CompletedTask;
        }

    protected override UniTask AfterHide()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                GameObject.Destroy(_buttons[i]);
            }
            _buttons.Clear();
            return UniTask.CompletedTask;
        }
    }
}