using UnityEngine;
using Zenject;

public class Cursor : MonoBehaviour
{
    [SerializeField] private CursorPoint _cursorPoint;

    private IInputService _inputService;
    private Camera _mainCamera;
    
    public CursorPoint CursorPoint => _cursorPoint;
    private IInput _input => _inputService.CurrentInput;
    private float _distanceFromHero = 1f;
    
    private Vector3 _centerPosition;
    private Vector3 _cursorPosition;
    private Vector3 _constrainedCursorPosition;
    private Vector3 _direction;

    private void Update()
    {
        _cursorPosition = _mainCamera.ScreenToWorldPoint(_input.CursorPosition);
        _cursorPosition.z = 0f;

        _centerPosition = transform.position;
        
        _direction = _cursorPosition - _centerPosition;
        _constrainedCursorPosition = _centerPosition + _direction.normalized * _distanceFromHero;

        _cursorPoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, -_direction);
        _cursorPoint.transform.position = _constrainedCursorPosition;
    }

    public void Enable(IInputService inputService, Camera mainCamera)
    {
        _inputService = inputService;
        _mainCamera = mainCamera;
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}