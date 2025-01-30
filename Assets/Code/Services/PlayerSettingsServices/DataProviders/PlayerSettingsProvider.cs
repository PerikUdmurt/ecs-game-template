using Code.Common.Extensions;
using Code.Services.PlayerSettingsServices.Datas;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.PlayerSettingsServices
{
    [UsedImplicitly]
    public class PlayerSettingsProvider : IPlayerSettingProvider
    {
        private const string PlayerSettingsPrefsName = "PlayerSettings";

        private readonly IInitialPlayerSettingProvider _initialProvider;
        private PlayerSettingsData _settingsData;

        public PlayerSettingsProvider(IInitialPlayerSettingProvider initialProvider)
        {
            _initialProvider = initialProvider;
            string json = PlayerPrefs.GetString(PlayerSettingsPrefsName);
            
            _settingsData = string.IsNullOrEmpty(json)
                ? _settingsData = initialProvider.GetInitialData()
                : json.FromJson<PlayerSettingsData>();
            
            Debug.Log($"[PlayerSettingsProvider] Loaded PlayerSettings with json = {json}");
        }
        
        public PlayerSettingsData SettingsData { get => _settingsData; }

        public void SetData(PlayerSettingsData data)
        {
            _settingsData = data;
            string json = _settingsData.ToJson();
            PlayerPrefs.SetString(PlayerSettingsPrefsName, json);
            Debug.Log($"[PlayerSettingsProvider] Saved PlayerSettings with json = {json}");
        }

        public void SetDefaultSettings() =>
            SetData(_initialProvider.GetInitialData());
    }
}