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
        bool GetLeftMouseButtonDown();
        bool GetLeftMouseButtonUp();
        bool GetRightMouseButtonDown();
        bool GetRightMouseButtonUp();
        bool GetLeftMouseButtonHold();
        bool GetRightMouseButtonHold();
        float GetMouseAxisHorizontal();
        float GetMouseAxisVertical();
    }
}