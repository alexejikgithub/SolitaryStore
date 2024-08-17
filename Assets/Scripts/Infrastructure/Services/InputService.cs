public class InputService : IInputService
{
    private IInput _currentInput;
    

    public IInput CurrentInput => _currentInput;
    

    public void SetCurrentInput(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.KeyboardAndMouse:
                SetKeyboardAndMouseInput();
                break;
            case InputType.NewInputSystem:
                SetNewInputSystem();
                break;
        }
    }

    public void SetKeyboardAndMouseInput()
    {
        _currentInput = new KeyboardAndMouseInput();
    }
   public void SetNewInputSystem()
    {
        _currentInput = new NewInputSystem();
    }

}