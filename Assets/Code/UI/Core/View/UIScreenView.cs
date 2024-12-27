using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.UI.Core
{
    public class UIScreenView : MonoBehaviour, IUIScreenView
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
            transform.SetAsLastSibling();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}