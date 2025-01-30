using Code.Services.PlayerSettingsServices.Datas;

namespace Code.Services.PlayerSettingsServices
{
    public interface IPlayerSettingProvider
    {
        PlayerSettingsData SettingsData { get; }
        void SetData(PlayerSettingsData data);
        void SetDefaultSettings();
    }
}