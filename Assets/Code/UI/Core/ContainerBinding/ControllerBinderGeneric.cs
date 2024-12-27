using UniRx;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Code.UI.Core.ContainerBinding
{
    [NoReflectionBaking]
    public class ControllerBinderGeneric<TController>
    {
        private BindStatement _bindStatement;
        protected ControllerBindInfo _info;

        public ControllerBinderGeneric(BindStatement bindStatement)
        {
            _info = new ControllerBindInfo();
            _info.ControllerType = typeof(TController);
            bindStatement.SetFinalizer(new ControllerBindingFinalizer(_info));
        }

        public ContollerViewBinderGeneric WithViewFromResourcePath(string prefabPath)
        {
            _info.ViewCreationType = EUIViewCreationType.ResourcePath;
            _info.PrefabPath = prefabPath;
            return new ContollerViewBinderGeneric(_info);
        }

        public ContollerViewBinderGeneric WithViewFromResolve()
        {
            _info.ViewCreationType = EUIViewCreationType.Resolve;
            return new ContollerViewBinderGeneric(_info);
        }
    }
}