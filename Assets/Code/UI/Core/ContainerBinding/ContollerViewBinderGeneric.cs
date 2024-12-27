using ModestTree;
using System;
using Zenject;

namespace Code.UI.Core.ContainerBinding
{
    [NoReflectionBaking]
    public class ContollerViewBinderGeneric
    {
        private ControllerBindInfo _info;

        public ContollerViewBinderGeneric(ControllerBindInfo info) =>
            _info = info;

        public ContollerViewBinderGeneric InLayer(EUILayerType layer)
        {
            _info.Layer = layer;
            _info.ParentTransformGetter = uiRoot => uiRoot.GetLayerTransform(layer).transform;
            return this;
        }

        public ContollerViewBinderGeneric OnInstantiated<T>(Action<InjectContext, T> callback)
        {
            _info.InstantiatedCallback = (ctx, obj) =>
            {
                Assert.That(obj == null || obj is T,
                    "Invalid generic argument to OnInstantiated! {0} must be type {1}", obj.GetType(), typeof(T));

                callback(ctx, (T)obj);
            };
            return this;
        }
    }
}