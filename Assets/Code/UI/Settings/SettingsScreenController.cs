using System;
using Code.Gameplay.DialogueSystem.UI.View;
using Code.Services.LocalizationServices;
using Code.UI.Core;
using Code.UI.Core.ContainerBinding;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Settings
{
    [UsedImplicitly]
    public class SettingsScreenController : UIScreenController<SettingsScreenView>
    {
        private readonly ILocalizationService _localizationService;

        public SettingsScreenController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            return UniTask.CompletedTask;
        }
    }

    public class SettingsScreenView : UIScreenView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _closeZone;
        [SerializeField] private Button _saveButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Slider _coundsSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Dropdown _languageDropdown;
        [SerializeField] private Dropdown _resolutionDropdown;
        
        public IObservable<Unit> OnCloseClicked => 
            _closeButton.OnClickAsObservable()
                .Merge(_closeZone.OnClickAsObservable());

        public IObservable<Unit> OnSaveClicked => _saveButton.OnClickAsObservable();
        public IObservable<Unit> OnCancelClicked => _cancelButton.OnClickAsObservable();
        public IObservable<float> OnSoundsValueChanged => _coundsSlider.OnValueChangedAsObservable();
        public IObservable<float> OnMusicValueChanged => _musicSlider.OnValueChangedAsObservable();
        public IObservable<int> OnResolutionValueChanged => _resolutionDropdown.OnValueChangedAsObservable();
        public IObservable<int> OnLanguageValueChanged => _languageDropdown.OnValueChangedAsObservable();
    }
    
    public class SettingsUIInstaller : Installer<SettingsUIInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindController<SettingsScreenController>()
                .WithViewFromResourcePath(UIConstants.SettingsScreen)
                .InLayer(EUILayerType.Screen);
        }
    }
}