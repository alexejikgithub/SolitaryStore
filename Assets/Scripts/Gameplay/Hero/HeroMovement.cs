using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private NavMeshAgent _agent;

    private IInputService _inputService;
    private IInput _input => _inputService.CurrentInput;

    private Vector2 _movementVector;
    private Vector3 _destinationVector;

    private bool _isEnabled;

    private void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public void EnableMovement(IInputService inputService)
    {
        _inputService = inputService;
        _isEnabled = true;
    }

    public void DisableMovement()
    {
        _isEnabled = false;
    }

    private void Update()
    {
        if (!_isEnabled)
        {
            return;
        }
        
        _movementVector = Vector2.zero;
        if (_input.Axis.sqrMagnitude > Constants.Epsilon)
        {
            _movementVector = _input.Axis;
            _movementVector.Normalize();
            _destinationVector = Vector3.one;
            _destinationVector.x = _movementVector.x;
            _destinationVector.y = _movementVector.y;
            _agent.Move(_destinationVector* Time.deltaTime * _agent.speed);
        }
    }
}