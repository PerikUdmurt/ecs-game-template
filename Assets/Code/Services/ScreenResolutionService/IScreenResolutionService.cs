namespace Code.Services.ScreenResolutionService
{
    public interface IScreenResolutionService
    {
        void SetResolution(int width, int height, bool isFullScreen);
    }
}