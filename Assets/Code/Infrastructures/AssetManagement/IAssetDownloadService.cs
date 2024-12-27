using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetDownloadService
    {
        float GetDownloadSizeMb();
        UniTask InitializeDownloadDataAsync();
        UniTask UpdateContentAsync();
    }
}