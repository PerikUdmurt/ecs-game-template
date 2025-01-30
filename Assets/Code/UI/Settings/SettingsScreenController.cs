using System.Collections.Generic;
using System.Linq;
using Code.Services.LocalizationServices;
using Code.Services.PlayerSettingsServices;
using Code.Services.PlayerSettingsServices.Datas;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Settings
{
    [UsedImplicitly]
    public class SettingsScreenController : UIScreenController<SettingsScreenView>
    {
        private readonly IPlayerSettingService _playerSettingService;
        private readonly IPlayerSettingProvider _settingsProvider;

        public SettingsScreenController(
            IPlayerSettingService playerSettingService,
            IPlayerSettingProvider settingsProvider)
        {
            _playerSettingService = playerSettingService;
            _settingsProvider = settingsProvider;
        }
        
        protected override UniTask BeforeShow(CompositeDisposable disposables)
        {
            ShowActualValues();

            _view.OnCloseClicked
                .Subscribe(_ => HideView().Forget())
                .AddTo(disposables);
            
            _view.OnCancelClicked
                .Subscribe(_ => OnCancelClicked())
                .AddTo(disposables);
            
            _view.OnSaveClicked
                .Subscribe(_ => OnSaveClicked())
                .AddTo(disposables);
            
            _view.OnLanguageValueChanged
                .Subscribe(OnLanguageChange)
                .AddTo(disposables);
            
            _view.OnMusicValueChanged
                .Subscribe(OnMusicChange)
                .AddTo(disposables);
            
            _view.OnResolutionValueChanged
                .Subscribe(OnResolutionChange)
                .AddTo(disposables);
            
            _view.OnSoundsValueChanged
                .Subscribe(OnSoundsChange)
                .AddTo(disposables);
            
            return UniTask.CompletedTask;
        }

        private void ShowActualValues()
        {
            PlayerSettingsData setData = _settingsProvider.SettingsData;
            
            UpdateLanguageView();
            UpdateResolutionView();
            _view.SetMusicSliderValue(setData.MusicVolume);
            _view.SetSoundsSliderValue(setData.SoundsVolume);
        }

        private void UpdateResolutionView()
        {
            List<Dropdown.OptionData> resolutions = _playerSettingService
                .GetAvailableResolutions().resolutions
                .Select(l => new Dropdown.OptionData(l.ToString()))
                .ToList();

            int index = _playerSettingService.GetAvailableResolutions().currentIndex;
            
            _view.SetResolutionDropdownOptions(resolutions, index);
        }

        private void UpdateLanguageView()
        {
            List<Dropdown.OptionData> locales = _playerSettingService
                .GetAvailableLocale().Item1
                .Select(l => new Dropdown.OptionData(l.ToString()))
                .ToList();
            
            ELocaleType currentLocale = _playerSettingService.GetAvailableLocale().Item2;
            var op = locales.First(o => o.text == currentLocale.ToString());
            int index = locales.IndexOf(op);
            
            _view.SetLanguageDropdownOptions(locales, index);
        }

        private void OnResolutionChange(int value)
        {
            Resolution resolution = _playerSettingService.GetAvailableResolutions().resolutions[value];
            _playerSettingService.SetResolution(resolution.width, resolution.height);
        }

        private void OnFullScreenChange(bool value)
        {
            _playerSettingService.SetFullscreen(value);
        }

        private void OnMusicChange(float value)
        {
            _playerSettingService.SetMusicVolume(value);
        }
        
        private void OnSoundsChange(float value)
        {
            _playerSettingService.SetSoundVolume(value);
        }

        private void OnLanguageChange(int value) =>
            _playerSettingService.SetLocale((ELocaleType)value);

        private void OnCancelClicked()
        {
            _playerSettingService.CancelModifications();
            ShowActualValues();
        }

        private void OnSaveClicked() =>
            _playerSettingService.SaveSettings();
    }
}