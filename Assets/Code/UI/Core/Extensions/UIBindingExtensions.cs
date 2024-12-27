using Zenject;

namespace Code.UI.Core.ContainerBinding
{
    public static class UIBindingExtensions
    {
        public static ControllerBinderGeneric<TController> BindController<TController>(this DiContainer di)
            where TController : IUIScreenController
        {
            return new ControllerBinderGeneric<TController>(di.StartBinding());
        }
    }
}