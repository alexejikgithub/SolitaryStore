using UnityEngine;
using Zenject;

public class Hero : MonoBehaviour
{
    
    [SerializeField] private HeroControls _controls;

    [Inject] private IInputService _inputService;
    [Inject] private CameraController _cameraController;
    
    public void Initialize()
    {
        _controls.EnableControls(_inputService, _cameraController.MainCamera);
    }

    private void OnDestroy()
    {
        _controls.DisableControls();
    }
}