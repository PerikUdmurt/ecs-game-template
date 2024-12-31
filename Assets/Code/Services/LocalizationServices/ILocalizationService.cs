using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Code.Services.LocalizationServices
{
    public interface ILocalizationService
    {
        UniTask SetLocale(ELocaleType locale);
        List<ELocaleType> GetAvailableLocale();
    }
}