using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.ScreenResolutionService
{
    [UsedImplicitly]
    public class ScreenResolutionService : IScreenResolutionService
    {
        public void SetResolution(int width, int height, bool isFullScreen)
        {
            Screen.SetResolution(width, height, isFullScreen);
        }
    }
}
