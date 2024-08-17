using UnityEngine.InputSystem;

public interface IInputService : IService
{
    public IInput CurrentInput { get; }

    public void SetCurrentInput(InputType inputType)
    {
    }
}

public enum InputType
{
    KeyboardAndMouse,
    NewInputSystem,
}