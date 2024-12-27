using Code.NodeBasedSystem.GraphLoaders;
using Code.NodeBasedSystem.GraphPlayer;
using Code.Progress.SaveLoadServices;
using Code.UI.Core;
using Code.UI.Develop.Debugger;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.UI.Develop
{
    public class DevelopHUDModel : IInitializable
    {
        private readonly DiContainer _container;

        private Dictionary<string, Action<string>> _actions;

        public Dictionary<string, Action<string>> Actions => _actions;

        public DevelopHUDModel(DiContainer diContainer)
        {
            _container = diContainer;
            _actions = new Dictionary<string, Action<string>>();
        }

        public void CreateDevelopHUDActions()
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
                NodeGraphPlayer graphPlayer = new NodeGraphPlayer(context, graphLoader, "7");
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
        }

        private void CreateAction(string label, Action<string> action) =>
            _actions.TryAdd(label, action);

        public void Initialize()
        {
            CreateDevelopHUDActions();
        }
    }
}