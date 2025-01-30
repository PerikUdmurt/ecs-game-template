using UnityEngine;

namespace Code.Services.ScreenResolutionService
{
    public interface IScreenResolutionService
    {
        void SetResolution(int width, int height, bool isFullScreen);
        void SetResolution(int resolutionIndex);
        void SetFullscreen(bool isFullscreen);
        Resolution[] GetAvailableResolutions();
        Resolution GetCurrentResolution();
        int GetCurrentResolutionIndex();
    }
}