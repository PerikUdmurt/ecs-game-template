using Code.Progress.Data;

namespace Code.Progress.Provider
{
    public interface IInitialProgressProvider
    {
        ProgressData GetInitialProgressData();
    }
}