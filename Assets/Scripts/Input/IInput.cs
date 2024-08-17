using System;
using UnityEngine;

public interface IInput
{
    event Action InteractPressed;
    Vector2 Axis { get; }
    Vector2 CursorPosition{ get; }
}