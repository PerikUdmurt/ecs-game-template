using Code.Gameplay.Features.Cursor;
using Code.Gameplay.Input.Mouse.Clickable.Systems;
using Code.Gameplay.Input.Mouse.Dragable;
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
            //EXECUTE
            Add(factory.Create<MousePositionInputSystem>());
            Add(factory.Create<MouseScrollWheelInputSystem>());
            Add(factory.Create<MouseButtonInputSystem>());
            Add(factory.Create<MouseAxisInputSystem>());
            Add(factory.Create<DragAndDropFeature>());
            Add(factory.Create<CursorFeature>());
            
            //CLEAN UP
            Add(factory.Create<ClickCleanUpSystem>());
            Add(factory.Create<DeselectCleanUpSystem>());
        }
    }
}
