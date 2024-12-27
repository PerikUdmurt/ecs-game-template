using Code.UI.Core.Controller;
using UnityEngine;
using Zenject;

namespace Code.UI.Core.Navigator.Inspector
{
    public class UINavigatorInspector : MonoBehaviour
    {
        private IUINavigator _navigator;
        
        [Inject]
        private void SetDependencies(IUINavigator navigator)
        {
            _navigator = navigator;
        }

        public void Show<TUIController>()
            where TUIController : class, ISimpleScreenController
        {
            _navigator.Show<TUIController>();
        }

        public void Hide<TUIController>() where TUIController : class, IUIScreenController
        {
            _navigator.Hide<TUIController>();
        }

        public void HideAll()
        {
            _navigator.HideAll();
        }

        public void HideAllInLayer(EUILayerType layer)
        {
            _navigator.HideAllInLayer(layer);
        }

        public void ShowOnlyMainHUD()
        {
            _navigator.ShowOnlyMainHUD();
        }
    }
}
