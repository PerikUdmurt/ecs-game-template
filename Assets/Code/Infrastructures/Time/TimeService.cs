using System;

namespace Code.Infrastructures.Time
{
    public class TimeService : ITimeService
    {
        public float DeltaTime => UnityEngine.Time.deltaTime;
        public float InGameTime => UnityEngine.Time.time;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}