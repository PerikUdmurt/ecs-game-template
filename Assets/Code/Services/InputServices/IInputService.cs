using UnityEngine;

namespace Code.Services.InputServices
{
    public interface IInputService
    {
        float GetAxisHorizontal();
        float GetAxisVertical();
        Vector2 GetMousePosition();
    }
}