using Code.Services.LocalizationServices;
using Code.Services.PlayerSettingsServices.Datas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.PlayerSettingsServices
{
    [UsedImplicitly]
    public class InitialPlayerSettingsDataProvider : IInitialPlayerSettingProvider
    {
        public PlayerSettingsData GetInitialData()
        {
            return new PlayerSettingsData()
            {
                MusicVolume = 100f,
                SoundsVolume = 100f,
                LocaleType = ELocaleType.English,
                ShowTutorial = true,
                GamepadVibrateEnabled = true,
                ScreenResolution = new ScreenResolutionData()
                {
                    Width = Screen.currentResolution.width,
                    Height = Screen.currentResolution.height,
                    Fullscreen = false,
                }
            };
        }
    }
}