using Code.Infrastructures.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Dragable
{
    public class DragableRegistrar : EntityComponentRegistrar, IDragHandler, IDropHandler, IPointerUpHandler
    {
        [SerializeField] private float _dragLerp;

        public override void RegisterComponent()
        {
            Entity.isDragable = true;
            Entity.AddDragLerp(_dragLerp);
        }

        public override void UnregisterComponent()
        {
            Entity.isDragable = false;
            Entity.RemoveDragLerp();
        }

        public void OnDrag(PointerEventData eventData)
        {
            Entity.isStartDragging = true;
            Entity.isDragging = true;
        }

        public void OnDrop(PointerEventData eventData)
        {
            Entity.isDragging = false;
            Entity.isDropped = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Entity.isDragging = false;
            Entity.isDropped = true;
        }
    }
}
