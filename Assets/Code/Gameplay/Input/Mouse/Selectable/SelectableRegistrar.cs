using Code.Infrastructures.View;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Gameplay.Input.Mouse.Selectable
{
    public class SelectableRegistrar : EntityComponentRegistrar, IPointerEnterHandler, IPointerExitHandler
    {
        public override void RegisterComponent()
        {
            Entity.AddSelectable(true);
        }

        public override void UnregisterComponent()
        {
            Entity.RemoveSelectable();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnEnter");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        
        }
    }
}
