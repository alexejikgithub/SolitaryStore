using System;
using UnityEngine;
using Zenject;

public class Hero : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private HeroControls _controls;

    [Inject] private IInputService _inputService;
    
    private void Start()
    {
        _controls.EnableControls(_inputService, _camera);
    }

    private void OnDestroy()
    {
        _controls.DisableControls();
    }
}