using Code.Gameplay.Input.Mouse.Clickable.Systems;
using Code.Gameplay.Input.Mouse.Dragable.Systems;
using Code.Gameplay.Input.Mouse.Selectable.Systems;
using Code.Gameplay.Input.Mouse.Systems;
using Code.Infrastructures.Factories;

namespace Code.Gameplay.Input.Mouse
{
    public class MouseFeature : Feature
    {
        public MouseFeature(ISystemFactory factory)
        {
            Add(factory.Create<MouseInputSystem>());
            Add(factory.Create<DragAndDropSystem>());
            Add(factory.Create<SelectableSystem>());
            Add(factory.Create<ClickableSystem>());
        }
    }
}
