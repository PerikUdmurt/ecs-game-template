using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructures.AssetManagement
{
  public interface IAssetProvider
  {
    void Initialize();
    UniTask<T> Load<T>(string address) where T : class;
    UniTask<T> Load<T>(AssetReference assetReference) where T : class;
    void CleanUp();
  }
}