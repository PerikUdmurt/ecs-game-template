using Code.Gameplay.Input.Mouse.Clickable.Systems;
using Code.Gameplay.Input.Mouse.Dragable.Systems;
using Code.Gameplay.Input.Mouse.Selectable.Systems;
using Code.Gameplay.Input.Mouse.Systems;
using Code.Infrastructures.Factories;
using JetBrains.Annotations;

namespace Code.Gameplay.Input.Mouse
{
    [UsedImplicitly]
    public class MouseFeature : Feature
    {
        public MouseFeature(ISystemFactory factory)
        {
            Add(factory.Create<MouseInputSystem>());
            //Add(factory.Create<MouseDragAndDropSystem>());
            //Add(factory.Create<SelectableSystem>());
            //Add(factory.Create<ClickableSystem>());
        }
    }
}
