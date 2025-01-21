using JetBrains.Annotations;
using UnityEngine;

namespace Code.Services.InputServices
{
    [UsedImplicitly]
    public class DesktopInputService : IInputService
    {
        public float GetAxisHorizontal() => Input.GetAxisRaw("Horizontal");
        public float GetAxisVertical() => Input.GetAxisRaw("Vertical");
        public float GetWheelScrollAxis() => Input.GetAxisRaw("Mouse ScrollWheel");
        public bool GetJumpDown() => Input.GetKeyDown(KeyCode.Space);
        public bool GetCrouchDown() => Input.GetKeyDown(KeyCode.C);
        public bool GetCrouchUp() => Input.GetKeyUp(KeyCode.C);
        public Vector2 GetMouseScreenPosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
        public bool IsAxisActive() => Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0;
    }
}