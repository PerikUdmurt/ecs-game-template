using UnityEngine;

namespace Code.Services.InputServices
{
    public interface IInputService
    {
        float GetAxisHorizontal();
        float GetAxisVertical();
        Vector2 GetMouseScreenPosition();
        float GetWheelScrollAxis();
        bool GetJumpDown();
        bool GetCrouchDown();
        bool GetCrouchUp();
        bool IsAxisActive();
    }
}