using Cysharp.Threading.Tasks;
using System;

namespace Code.UI.Core
{
    public interface IUIScreenController : IDisposable
    {
        public EUILayerType UILayer { get; }
        UniTask HideView();
    }
}