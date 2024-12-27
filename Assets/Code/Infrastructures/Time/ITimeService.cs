using System;

namespace Code.Infrastructures.Time
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        float InGameTime { get; }
        DateTime UtcNow { get; }
    }
}