using System;
using System.Collections.Generic;
using Code.UI.Core.Controller;
using ModestTree;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Code.UI.Core.ContainerBinding
{
    [NoReflectionBaking]
    public class ControllerBindingFinalizer : IBindingFinalizer
    {
        public BindingInheritanceMethods BindingInheritanceMethod => BindingInheritanceMethods.None;
        public readonly ControllerBindInfo Info;

        public ControllerBindingFinalizer(ControllerBindInfo presenterBindInfo)
        {
            Info = presenterBindInfo;
        }

        public void FinalizeBinding(DiContainer container)
        {
            switch (Info.ViewCreationType)
            {
                case EUIViewCreationType.ResourcePath:
                    Assert.That(!string.IsNullOrEmpty(Info.PrefabPath), $"Please, choose resource path to view prefab: {Info.ControllerType.PrettyName()}");
                    RegisterViewPrefab(container);
                    break;
                
                case EUIViewCreationType.Resolve:
                    Assert.That(!string.IsNullOrEmpty(Info.AssetPath), $"Please, choose asset path for prefab: {Info.ControllerType.PrettyName()}");
                    break;
            }

            Assert.That(Info.ParentTransformGetter != null, $"Please, use InLayer: {Info.ControllerType.PrettyName()}");
			
            RegisterController(container);
        }

        private void RegisterViewPrefab(DiContainer container)
        {
            var viewType = Info.ControllerType.GetArgumentsOfInheritedOpenGenericClass(typeof(UIScreenController<>))[0];
            var gameObjectBindInfo = new GameObjectCreationParameters()
            {
                ParentTransformGetter = ic => Info.ParentTransformGetter(ic.Container.Resolve<UIRoot>()),
                Name = viewType.Name.Substring(2).SplitPascalCase(),
            };

            var prefabCreator = new PrefabInstantiatorCached(
                new PrefabInstantiator(
                    container,
                    gameObjectBindInfo,
                    viewType,
                    new List<Type>() { viewType },
                    new List<TypeValuePair>(),
                    new PrefabProviderResource(Info.PrefabPath),
                    (ic, o) => 
                    {
                        ((MonoBehaviour)o).gameObject.SetActive(false);
                    }
                    )
                );

            container.RegisterProvider(new BindingId(viewType, null),
                null, new GetFromPrefabComponentProvider(viewType, prefabCreator, true), false);
        }

        private void RegisterController(DiContainer container)
        {
            var cached = new CachedProvider(new TransientProvider(Info.ControllerType, container, 
                new [] { new TypeValuePair(typeof(EUILayerType), Info.Layer)},
                $"Bind Contoller {Info.ControllerType.PrettyName()}", 
                null, Info.InstantiatedCallback));
            container.RegisterProvider(new BindingId(Info.ControllerType, null),
                null, cached, false);
            container.RegisterProvider(new BindingId(typeof(IDisposable), null),
                null, cached, false);
        }
    }
}