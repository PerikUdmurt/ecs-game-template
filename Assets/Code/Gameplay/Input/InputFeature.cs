using Code.Gameplay.Input.Mouse;
using Code.Gameplay.Input.Systems;
using Code.Infrastructures.Factories;
using Code.Services.InputServices;

namespace Code.Gameplay.Input
{
    public class InputFeature : Feature
    {
        public InputFeature(ISystemFactory factory) 
        {
            Add(factory.Create<InitializeInputSystem>());
            Add(factory.Create<EmitInputSystem>());
            Add(factory.Create<MouseFeature>());
        }
    }
}