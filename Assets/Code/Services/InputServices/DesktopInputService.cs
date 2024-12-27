using UnityEngine;

namespace Code.Services.InputServices
{
    public class DesktopInputService : IInputService
    {
        public float GetAxisHorizontal() => Input.GetAxisRaw("Horizontal");
        public float GetAxisVertical() => Input.GetAxisRaw("Vertical");
        public Vector2 GetMousePosition() => Camera.main.ScreenToWorldPoint(Input.mousePosition);
        public bool IsAxisActive() => Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0;
    }
}