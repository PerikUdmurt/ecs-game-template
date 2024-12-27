using System;
using UnityEngine;
using UnityEngine.Localization;

namespace Code.Progress.ProgressTokens.Configs
{
    [CreateAssetMenu(menuName = "Configs/Progress/ProgressTokensConfig", fileName = "ProgressTokensConfig")]
    public class ProgressTokensConfig : ScriptableObject
    {
        private SerializableDictionary<string, ProgressTokenConfig> tokens;
    }

    [Serializable]
    public struct ProgressTokenConfig
    {
        public LocalizedString name;
        public LocalizedString description;
    }
}