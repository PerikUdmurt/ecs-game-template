using Code.Services.PlayerSettingsServices.Datas;

namespace Code.Services.PlayerSettingsServices
{
    public class PlayerSettingsProvider : IPlayerSettingProvider
    {
        private PlayerSettingsData _settingsData;
        
        public PlayerSettingsData SettingsData { get => _settingsData; }

        public void SetData(PlayerSettingsData data)
        {
            _settingsData = data;
        }
    }
}