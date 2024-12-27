using Code.Infrastructures.View;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Clickable
{
    public class ClickableRegistrar : EntityComponentRegistrar, IPointerClickHandler
    {
        public override void RegisterComponent() =>
            Entity.AddClackable(true);

        public override void UnregisterComponent() =>
            Entity.RemoveClackable();

        public void OnPointerClick(PointerEventData eventData)
        {
            Entity.isClicked = true;
        }
    }
}
