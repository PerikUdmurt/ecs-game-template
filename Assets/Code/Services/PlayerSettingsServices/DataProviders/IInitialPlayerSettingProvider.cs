using Code.Services.PlayerSettingsServices.Datas;

namespace Code.Services.PlayerSettingsServices
{
    public interface IInitialPlayerSettingProvider
    {
        PlayerSettingsData GetInitialData();
    }
}