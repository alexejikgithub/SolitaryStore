using UnityEngine;

public class KeyboardMouseInput : IInput
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    
    private Vector2 _axis;
    public  Vector2 Axis
    {
        get
        {
            _axis.x = Input.GetAxis(Horizontal);
            _axis.y = Input.GetAxis(Vertical);
            return _axis;
        }
    }

    public Vector2 CursorPosition => Input.mousePosition;
}