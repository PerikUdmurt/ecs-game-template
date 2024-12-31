using System.Collections.Generic;
using Code.Services.LocalizationServices;
using Code.Services.ScreenResolutionService;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.PlayerSettingsServices
{
    [UsedImplicitly]
    public class PlayerSettingsService : IPlayerSettingService
    {
        private readonly ILocalizationService _localizationService;
        private readonly IPlayerSettingProvider _settingsProvider;
        private readonly IScreenResolutionService _screenResolutionService;

        public PlayerSettingsService(
            ILocalizationService localizationService, 
            IPlayerSettingProvider settingsProvider,
            IScreenResolutionService screenResolutionService)
        {
            _localizationService = localizationService;
            _settingsProvider = settingsProvider;
            _screenResolutionService = screenResolutionService;
        }
        
        public void SetResolution(int width, int height, bool isFullscreen)
        {
            _screenResolutionService.SetResolution(width, height, isFullscreen);
        }

        public void SetSoundVolume(float volume)
        {
            Debug.LogWarning("[PlayerSettingsService] SetSoundVolume called but not assigned]");
        }

        public void SetMusicVolume(float volume)
        {
            Debug.LogWarning("[PlayerSettingsService] SetMusicVolume called but not assigned]");
        }

        public void SetLocale(ELocaleType localeType)
        {
            _localizationService.SetLocale(localeType).Forget();
        }

        public List<ELocaleType> GetAvailableLocale() =>
            _localizationService.GetAvailableLocale();

        public void SetGamepadVibration(bool vibrate)
        {
            Debug.LogWarning("[PlayerSettingsService] SetGamepadVibration called but not assigned]");
        }

        public void SetShowTutorial(bool showTutorial)
        {
            Debug.LogWarning("[PlayerSettingsService] SetShowTutorial called but not assigned]");
        }
    }

    public interface IPlayerSettingService
    {
        void SetResolution(int width, int height, bool isFullscreen);
        void SetSoundVolume(float volume);
        void SetMusicVolume(float volume);
        void SetLocale(ELocaleType localeType);
        List<ELocaleType> GetAvailableLocale();
        void SetGamepadVibration(bool vibrate);
        void SetShowTutorial(bool showTutorial);
    }
}
