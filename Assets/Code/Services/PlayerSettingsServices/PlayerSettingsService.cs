using System.Collections.Generic;
using Code.Services.Audio;
using Code.Services.LocalizationServices;
using Code.Services.PlayerSettingsServices.Datas;
using Code.Services.ScreenResolutionService;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Services.PlayerSettingsServices
{
    [UsedImplicitly]
    public class PlayerSettingsService : IPlayerSettingService, IInitializable
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPlayerSettingProvider _settingsProvider;
        private readonly IScreenResolutionService _screenResolutionService;
        private readonly IAusioService _ausioService;
        
        private PlayerSettingsData _tempSettings;

        public PlayerSettingsService(
            ILocalizationService localizationService,
            IPlayerSettingProvider settingsProvider,
            IScreenResolutionService screenResolutionService, 
            IAusioService ausioService)
        {
            _localizationService = localizationService;
            _settingsProvider = settingsProvider;
            _screenResolutionService = screenResolutionService;
            _ausioService = ausioService;
        }

        public void Initialize()
        {
            SetSavedSettings();
        }

        public void SetResolution(int width, int height)
        {
            _tempSettings.ScreenResolution.Width = width;
            _tempSettings.ScreenResolution.Height = height;
            _screenResolutionService.SetResolution(width, height, _tempSettings.ScreenResolution.Fullscreen);
        }

        public (Resolution[] resolutions, int currentIndex) GetAvailableResolutions()
        {
             Resolution[] resolutions = _screenResolutionService.GetAvailableResolutions();
             int currentResolutionIndex = _screenResolutionService.GetCurrentResolutionIndex();
             return (resolutions, currentResolutionIndex);
        }

        public void SetFullscreen(bool value)
        {
            _tempSettings.ScreenResolution.Fullscreen = value;
            _screenResolutionService.SetFullscreen(value);
        }

        public void SetSoundVolume(float volume)
        {
            _tempSettings.SoundsVolume = volume;
            _ausioService.SetSoundVolume(volume);
        }

        public void SetMusicVolume(float volume)
        {
            _tempSettings.MusicVolume = volume;
            _ausioService.SetMusicVolume(volume);
        }

        public void SetLocale(ELocaleType localeType)
        {
            _tempSettings.LocaleType = localeType;
            _localizationService.SetLocale(localeType).Forget();
        }

        public (List<ELocaleType>, ELocaleType) GetAvailableLocale() =>
            (_localizationService.GetAvailableLocale(), _localizationService.GetCurrentLocale());

        public void SetGamepadVibration(bool vibrate)
        {
            _tempSettings.GamepadVibrateEnabled = vibrate;
            Debug.LogWarning("[PlayerSettingsService] SetGamepadVibration called but not assigned]");
        }

        public void SetShowTutorial(bool showTutorial)
        {
            _tempSettings.ShowTutorial = showTutorial;
            Debug.LogWarning("[PlayerSettingsService] SetShowTutorial called but not assigned]");
        }

        public void SaveSettings() =>
            _settingsProvider.SetData(_tempSettings);

        public void CancelModifications() =>
            SetSavedSettings();
            
        public void SetDefaultSettings()
        {
            _settingsProvider.SetDefaultSettings();
            SetSavedSettings();
        }
        
        private void SetSavedSettings()
        {
            PlayerSettingsData data = _settingsProvider.SettingsData;
            _tempSettings = data;
            SetResolution(data.ScreenResolution.Width, data.ScreenResolution.Height);
            SetFullscreen(data.ScreenResolution.Fullscreen);
            SetSoundVolume(data.SoundsVolume);
            SetMusicVolume(data.MusicVolume);
            SetLocale(data.LocaleType);
            SetGamepadVibration(data.GamepadVibrateEnabled);
            SetShowTutorial(data.ShowTutorial);
        }
    }
}
