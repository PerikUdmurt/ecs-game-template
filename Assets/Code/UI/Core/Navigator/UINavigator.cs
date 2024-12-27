using System;
using System.Collections.Generic;
using System.Linq;
using Code.UI.Core.Controller;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.UI.Core.Navigator
{
    [UsedImplicitly]
    public class UINavigator : IUINavigator
    {
        private readonly DiContainer _container;
        private readonly Dictionary<Type, ISimpleScreenController> _createdControllersByType;
        private readonly ReactiveDictionary<Type, ISimpleScreenController> _openedControllers;

        public UINavigator(DiContainer container)
        {
            _createdControllersByType = new Dictionary<Type, ISimpleScreenController>();
            _openedControllers = new ReactiveDictionary<Type, ISimpleScreenController>();
            _container = container;
        }
        
        public void Show<TUIController>(Action<TUIController> afterShowCallback = null) where TUIController : class, ISimpleScreenController
        {
            if (!_createdControllersByType.ContainsKey(typeof(TUIController)))
            {
                if (!TryResolveController(out TUIController cont)) return;
                
                _createdControllersByType.Add(typeof(TUIController), cont);
            }
            
            ISimpleScreenController controller = _createdControllersByType[typeof(TUIController)];

            if (afterShowCallback == null)
                controller.Show().Forget();
            else
                controller.Show().ContinueWith(() => afterShowCallback((TUIController)controller)).Forget();
            
            
            _openedControllers.TryAdd(controller.GetType(), controller);
        }

        public void Perform<TUIController>(Action<TUIController> action) where TUIController : class, IUIScreenController
        {
            TUIController controller = _container.TryResolve<TUIController>();
            if (controller != null)
                action(controller);
            else
                Debug.LogError($"[UI_ROOT] Controller {typeof(TUIController).Name}: Unable to resolve");
        }

        public void Hide<TUIController>() where TUIController : class, IUIScreenController
        {
            if (_openedControllers.ContainsKey(typeof(TUIController)))
            {
                _openedControllers[typeof(TUIController)].HideView();
                _openedControllers.Remove(typeof(TUIController));
            }
            else
            {
                Debug.LogError($"[UI_ROOT] Controller {typeof(TUIController).Name}: attempt to hide closed or not instantiated controller");
            }
        }

        public void HideAll()
        {
            HideAllInLayer(EUILayerType.Popup);
            HideAllInLayer(EUILayerType.Screen);
            HideAllInLayer(EUILayerType.MainHud);
        }

        public void HideAllInLayer(EUILayerType layer)
        {
            _openedControllers.Values
                .Where(c => c.UILayer == layer)
                .ForEach(c =>
                {
                    c.HideView();
                    _openedControllers.Remove(c.GetType());
                });
        }

        public void ShowOnlyMainHUD()
        {
            HideAll();
            _createdControllersByType.Values
                .Where(c => c.UILayer == EUILayerType.MainHud)
                .ForEach(c => c.Show().Forget());
        }
        
        private bool TryResolveController<TUIController>(out TUIController cont)
            where TUIController : class, ISimpleScreenController
        {
            cont = _container.TryResolve<TUIController>();

            if (cont == null)
            {
                Debug.LogError($"[UI_ROOT] Controller {typeof(TUIController).Name}: Unable to resolve");
                return false;
            }

            return true;
        }
    }
}