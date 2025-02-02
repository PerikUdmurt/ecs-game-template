using Entitas;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Code.Infrastructures.Factories
{
    [UsedImplicitly]
    public class SystemFactory : ISystemFactory
    {
        private readonly DiContainer _diContainer;

        public SystemFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create<T>() where T : ISystem =>
            _diContainer.Instantiate<T>();

        public T Create<T>(params object[] args) where T : ISystem =>
            _diContainer.Instantiate<T>(args);
    }
}