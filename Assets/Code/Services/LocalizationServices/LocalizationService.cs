using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.Localization.Settings;

namespace Code.Services.LocalizationServices
{
    [UsedImplicitly]
    public class LocalizationService : ILocalizationService
    {
        public async UniTask SetLocale(ELocaleType locale)
        {
            await LocalizationSettings.InitializationOperation.ToUniTask();
            
            LocalizationSettings.SelectedLocale = 
                LocalizationSettings.AvailableLocales.Locales
                    .First(l => l.CustomFormatterCode == locale.ToSimpleString());
        }

        public List<ELocaleType> GetAvailableLocale() 
            => LocalizationSettings.AvailableLocales.Locales
                .Select(l => l.CustomFormatterCode.ToLocaleType())
                .ToList();
    }
}
