using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.InputServices
{
    [UsedImplicitly]
    public class DesktopInputService : IInputService
    {
        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        
        public float GetAxisHorizontal() => Input.GetAxisRaw(HorizontalInput);
        public float GetAxisVertical() => Input.GetAxisRaw(VerticalInput);
        public float GetWheelScrollAxis() => Input.GetAxisRaw(MouseScrollInput);
        public bool GetJumpDown() => Input.GetKeyDown(KeyCode.Space);
        public bool GetCrouchDown() => Input.GetKeyDown(KeyCode.C);
        public bool GetCrouchUp() => Input.GetKeyUp(KeyCode.C);
        public bool GetLeftMouseButtonDown() => Input.GetMouseButtonDown(0);
        public bool GetLeftMouseButtonUp() => Input.GetMouseButtonUp(0);
        public bool GetRightMouseButtonDown() => Input.GetMouseButtonDown(1);
        public bool GetRightMouseButtonUp() => Input.GetMouseButtonUp(1);
        public bool GetLeftMouseButtonHold() => Input.GetMouseButton(0);
        public bool GetRightMouseButtonHold() => Input.GetMouseButton(1);
        public Vector2 GetMouseScreenPosition() => Input.mousePosition;
        public float GetMouseAxisHorizontal() => Input.GetAxisRaw(MouseXInput);
        public float GetMouseAxisVertical() => Input.GetAxisRaw(MouseYInput);
        public bool IsAxisActive() => Input.GetAxisRaw(HorizontalInput) != 0 && Input.GetAxisRaw(VerticalInput) != 0;
    }
}