using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.NodeBasedSystem.Core.Datas;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Code.Services.LocalizationServices
{
    [UsedImplicitly]
    public class LocalizationService : ILocalizationService
    {
        public async UniTask SetLocale(ELocaleType locale)
        {
            await LocalizationSettings.InitializationOperation.ToUniTask();
            
            Locale newLocale = 
                LocalizationSettings.AvailableLocales.Locales
                    .FirstOrDefault(l => l.Identifier.Code == locale.ToSimpleString());

            if (newLocale == null)
            {
                StringBuilder str = new StringBuilder(
                    $"Locale with identifier code <{locale.ToSimpleString()}> is not supported. " +
                    $"Available locales {LocalizationSettings.AvailableLocales.Locales.Count}:");
                LocalizationSettings.AvailableLocales.Locales.ForEach(c => str.Append(c.Identifier.Code));
                Debug.LogError(str.ToString());
                return;
            }
            
            LocalizationSettings.SelectedLocale = newLocale;
            Debug.Log($"[LocalizationService] Set locale {locale}");
        }

        public List<ELocaleType> GetAvailableLocale()
            => LocalizationSettings.AvailableLocales.Locales
                .Select(l => l.Identifier.Code.ToLocaleType())
                .ToList();
        
        public ELocaleType GetCurrentLocale() => 
            LocalizationSettings.SelectedLocale.Identifier.Code.ToLocaleType();
        
        public string GetLocalizedString(string entryKey, string tableKey)
            => LocalizationSettings.StringDatabase.GetLocalizedString(tableKey, entryKey);
        
        public string GetLocalizedString(LocalizedStringData data)
            => GetLocalizedString(data.entryKey, data.tableKey); 
    }
}
