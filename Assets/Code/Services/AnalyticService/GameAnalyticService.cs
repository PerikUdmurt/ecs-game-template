using GameAnalyticsSDK;
using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.AnalyticService
{
    [UsedImplicitly]
    public class GameAnalyticService : IAnalyticService
    {
        public void Initialize() =>
            GameAnalytics.Initialize();

        public void SendEvent(string eventName)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Test Event");
            Debug.Log("[AnalyticService] Sending event]");
        }

        public void StartTestTimer() =>
            GameAnalytics.StartTimer("Test Timer");
    }

    public interface IAnalyticService
    {
        void Initialize();
        void SendEvent(string eventName);
        void StartTestTimer();
    }
}