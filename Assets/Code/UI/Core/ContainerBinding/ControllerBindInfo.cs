using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.UI.Core.ContainerBinding
{
    [NoReflectionBaking]
    public class ControllerBindInfo
    {
        public EUIViewCreationType ViewCreationType { get; set; }
        public Type ControllerType { get; set; }
        
        public AssetReference AssetReference { get; set; }
        public string AssetPath { get; set; } = "";
        public string PrefabPath { get; set; } = "";
        public Func<UIRoot, Transform> ParentTransformGetter { get; set; }
        public EUILayerType Layer { get; set; }
        public Action<InjectContext, object> InstantiatedCallback { get; set; }
    }
}