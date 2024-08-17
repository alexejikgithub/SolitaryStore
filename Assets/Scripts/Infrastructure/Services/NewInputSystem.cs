using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : IInput
{
    public event Action InteractPressed;
    
    
    private Controls _controls;

    public NewInputSystem()
    {
        _controls = new Controls();
        _controls.Player.Enable();
        
        _controls.Player.Interact.performed +=OnInteractPressed;
    }
    
    public  Vector2 Axis => _controls.Player.Movement.ReadValue<Vector2>();

    public Vector2 CursorPosition => Input.mousePosition;



    private void OnInteractPressed(InputAction.CallbackContext context )
    {
        InteractPressed?.Invoke();
    }

}