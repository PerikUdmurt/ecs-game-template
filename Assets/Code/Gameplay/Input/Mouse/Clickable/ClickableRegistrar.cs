using Code.Infrastructures.View;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Clickable
{
    public class ClickableRegistrar : EntityComponentRegistrar, IPointerClickHandler
    {
        public override void RegisterComponent() =>
            Entity.isClickable = true;

        public override void UnregisterComponent() =>
            Entity.isClickable = false;

        public void OnPointerClick(PointerEventData eventData)
        {
            Entity.isClicked = true;
        }
    }
}
