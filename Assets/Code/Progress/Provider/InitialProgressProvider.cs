using System.Linq;
using Code.Progress.Data;
using Code.Progress.PlayerResources.Configs;
using Code.Progress.PlayerStorage;
using Code.Progress.ProgressTokens;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Progress.Provider
{
    [UsedImplicitly]
    public class InitialProgressProvider : IInitialProgressProvider
    {
        private readonly PlayerResourcesInitialConfig _resourcesConfig;

        public InitialProgressProvider(PlayerResourcesInitialConfig resourcesConfig)
        {
            _resourcesConfig = resourcesConfig;
        }
    
        public ProgressData GetInitialProgressData()
        {
            ProgressData progressData = new ProgressData();
      
            progressData.data.entitySnapshots.Add(new EntitySnapshot()
            {
                components = new()
                {
                    new PlayerResourcesComponent(),
                    new ProgressTokenStorage() { Value = new()},
                    new MaxBenzineComponent() { Value = _resourcesConfig.maxBenzine },
                    new BenzineComponent() { Value = _resourcesConfig.initialBenzine },
                    new MaxMoneyComponent() { Value = _resourcesConfig.maxMoney },
                    new MoneyComponent() { Value = _resourcesConfig.initialMoney },
                    new MaxRatingComponent() { Value = _resourcesConfig.maxRating },
                    new RatingComponent() { Value = _resourcesConfig.initialRating },
                    new MaxVolitionComponent() { Value = _resourcesConfig.maxVolition },
                    new VolitionComponent() { Value = _resourcesConfig.initialVolition }
                }
            });
            
            return progressData;
        }
    }
}