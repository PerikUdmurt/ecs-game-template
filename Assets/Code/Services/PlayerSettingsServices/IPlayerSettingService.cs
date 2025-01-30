using System.Collections.Generic;
using Code.Services.LocalizationServices;
using UnityEngine;

namespace Code.Services.PlayerSettingsServices
{
    public interface IPlayerSettingService
    {
        void SetResolution(int width, int height);
        void SetSoundVolume(float volume);
        void SetMusicVolume(float volume);
        void SetLocale(ELocaleType localeType);
        (List<ELocaleType>, ELocaleType) GetAvailableLocale();
        void SetGamepadVibration(bool vibrate);
        void SetShowTutorial(bool showTutorial);
        void SaveSettings();
        void CancelModifications();
        void SetDefaultSettings();
        (Resolution[] resolutions, int currentIndex) GetAvailableResolutions();
        void SetFullscreen(bool value);
    }
}