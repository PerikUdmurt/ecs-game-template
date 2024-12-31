using System;
using Code.Services.LocalizationServices;

namespace Code.Services.PlayerSettingsServices.Datas
{
    [Serializable]
    public class PlayerSettingsData
    {
        public float MusicVolume;
        public float SoundsVolume;
        public ELocaleType LocaleType;
        public bool ShowTutorial;
        public bool GamepadVibrateEnabled;
        public ScreenResolutionData ScreenResolution;
    }

    [Serializable]
    public class ScreenResolutionData
    {
        public int Width;
        public int Height;
        public bool Fullscreen;
    }
}