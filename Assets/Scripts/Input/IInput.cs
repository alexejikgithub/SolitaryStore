using UnityEngine;

public interface IInput
{
    Vector2 Axis { get; }
    Vector2 CursorPosition{ get; }
}