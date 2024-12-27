using System;
using Code.UI.Core.Controller;

namespace Code.UI.Core
{
    public interface IUINavigator
    {
        void Show<TUIController>(Action<TUIController> afterShowCallback = null) where TUIController : class, ISimpleScreenController;
        void Perform<TUIController>(Action<TUIController> action) where TUIController : class, IUIScreenController;
        void Hide<TUIController>() where TUIController : class, IUIScreenController;
        void HideAll();
        void HideAllInLayer(EUILayerType layer);
        void ShowOnlyMainHUD();
    }
}