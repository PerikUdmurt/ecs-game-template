using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructures.Factories
{
    public interface IAsyncMonoFactory
    {
        UniTask<T> Create<T>(AssetReference assetReference) where T : MonoBehaviour;
        UniTask<T> Create<T>(string assetPath) where T : MonoBehaviour;
    }
}