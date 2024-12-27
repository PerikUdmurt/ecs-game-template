using System;

namespace Code.Services.LocalizationServices
{
    public static class LocaleExtensions
    {
        private const string English = "en";
        private const string French = "fr";
        private const string Spanish = "es";
        private const string Russian = "ru";
        
        public static string ToSimpleString(this ELocaleType locale)
        {
            return locale switch
            {
                ELocaleType.English => English,
                ELocaleType.Russian => Russian,
                _ => throw new ArgumentOutOfRangeException(nameof(locale), locale, null)
            };
        }

        public static ELocaleType ToLocaleType(this string locale)
        {
            return locale switch
            {
                English => ELocaleType.English,
                Russian => ELocaleType.Russian,
                _ => throw new ArgumentOutOfRangeException(nameof(locale), locale, null)
            };
        }
    }
}