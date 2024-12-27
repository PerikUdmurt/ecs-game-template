using System;

namespace Code.Infrastructures.SceneLoaders
{
    public interface ISceneLoader
    {
        void Load(SceneName sceneName, Action onLoaded = null);
    }
}