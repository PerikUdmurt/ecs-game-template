using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Datas;
using Cysharp.Threading.Tasks;

namespace Code.Services.LocalizationServices
{
    public interface ILocalizationService
    {
        UniTask SetLocale(ELocaleType locale);
        List<ELocaleType> GetAvailableLocale();
        string GetLocalizedString(string entryKey, string tableKey);
        string GetLocalizedString(LocalizedStringData data);
    }
}