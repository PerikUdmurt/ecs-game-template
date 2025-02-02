using Code.Infrastructures.View;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Selectable
{
    public class SelectableRegistrar : EntityComponentRegistrar, IPointerEnterHandler, IPointerExitHandler
    {
        public override void RegisterComponent()
        {
            Entity.isSelectable = true;
        }

        public override void UnregisterComponent()
        {
            Entity.isSelectable = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Entity.isSelected = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Entity.isSelected = false;
        }
    }
}
