using Code.NodeBasedSystem.GraphLoaders;
using Code.NodeBasedSystem.GraphPlayer;
using Code.Progress.SaveLoadServices;
using Code.UI.Core;
using Code.UI.Develop.Debugger;
using System;
using System.Collections.Generic;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.Core.NodeGraphPlayer;
using Code.UI.Settings;
using JetBrains.Annotations;
using Zenject;

namespace Code.UI.Develop
{
    [UsedImplicitly]
    public class DevelopHUDModel : IInitializable
    {
        private readonly DiContainer _container;

        public Dictionary<string, Action<string>> Actions { get; }

        public DevelopHUDModel(DiContainer diContainer)
        {
            _container = diContainer;
            Actions = new Dictionary<string, Action<string>>();
        }

        private void CreateDevelopHUDActions()
        {
            CreateAction("ShowDebugger", (str) =>
            {
                IUINavigator navigator = _container.TryResolve<IUINavigator>();
                navigator.Show<UIDebuggerController>();
            });

            CreateAction("StartTestGraph", (str) =>
            {
                IGraphLoader graphLoader = _container.TryResolve<IGraphLoader>();
                NodeSystemContext context = _container.TryResolve<NodeSystemContext>();
                INodeConditionVerifyService verifyService = _container.TryResolve<INodeConditionVerifyService>();
                NodeGraphPlayer graphPlayer = new NodeGraphPlayer(context, verifyService, graphLoader, "TestGraphPlayer");
                graphPlayer.StartGraph(str);
            });

            CreateAction("SaveProgress", (str) =>
            {
                ISaveLoadService progress = _container.TryResolve<ISaveLoadService>();
                progress.SaveProgress();
            });

            CreateAction("LoadProgress", (str) =>
            {
                ISaveLoadService progress = _container.TryResolve<ISaveLoadService>();
                progress.LoadProgress();
            });
            
            CreateAction("Open Settings", (str) =>
            {
                IUINavigator navigator = _container.TryResolve<IUINavigator>();
                navigator.Show<SettingsScreenController>();
            });
        }

        private void CreateAction(string label, Action<string> action) =>
            Actions.TryAdd(label, action);

        public void Initialize()
        {
            CreateDevelopHUDActions();
        }
    }
}