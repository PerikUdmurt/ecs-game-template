namespace Code.Common.Extensions
{
    public static class StringExtensions 
    {
        public static string Enscrypt(this string text, string enscryptionKey)
        {
            string modifierData = "";

            for (int i = 0; i < text.Length; i++)
            {
                modifierData += (char)(text[i] ^ (enscryptionKey[i % enscryptionKey.Length]));
            }
            
            return modifierData;
        }
    }
}
