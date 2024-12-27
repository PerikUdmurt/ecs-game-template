using Code.NodeBasedSystem.Progress.Datas;
using UnityEngine;

namespace Code.Progress.PlayerResources.Configs
{
    [CreateAssetMenu(fileName = "PlayerResourcesInitialConfig", menuName = "Configs/Progress/PlayerResourcesInitialConfig")]
    public class PlayerResourcesInitialConfig : ScriptableObject
    {
        [Tooltip("Initial Volition / Начальное значение для воли")]
        public int initialVolition = 50;
    
        [Tooltip("Max Volition / Максимальное значение для воли")]
        public int maxVolition = 100;
    
        [Tooltip("Initial Money / Начальное значение денег")]
        public int initialMoney = 50;
    
        [Tooltip("Max Money / Максимальное значение для денег")]
        public int maxMoney = int.MaxValue;
    
        [Tooltip("Initial Benzine / Начальное значение для бензина")]
        public int initialBenzine = 50;
    
        [Tooltip("Max Benzine / Максимальное значение для бензина")]
        public int maxBenzine = 100;
    
        [Tooltip("Initial Rating / Начальное значение рейтинга")]
        public float initialRating = 4.5f;
    
        [Tooltip("Max Rating / Максимальное значение рейтинга")]
        public float maxRating = 5f;
    }
}
