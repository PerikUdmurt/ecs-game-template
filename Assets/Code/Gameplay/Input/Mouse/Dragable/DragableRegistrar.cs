using Code.Infrastructures.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Dragable
{
    public class DragableRegistrar : EntityComponentRegistrar, IDragHandler, IPointerUpHandler
    {
        [SerializeField] private float _dragLerp;

        public override void RegisterComponent()
        {
            Entity.AddDragable(true);
            Entity.AddDragLerp(_dragLerp);
        }

        public override void UnregisterComponent()
        {
            Entity.RemoveDragable();
            Entity.RemoveDragLerp();
        }

        public void OnDrag(PointerEventData eventData) =>
            Entity.isDragging = true;

        public void OnPointerUp(PointerEventData eventData) =>
            Entity.isDragging = false;
    }
}
