using UnityEngine;
using Zenject;

public class Hero : MonoBehaviour
{
    
    [SerializeField] private HeroControls _controls;
    [SerializeField] private HeroInteractor interactor;
    [SerializeField] private HeroHolder _holder;

    [Inject] private IInputService _inputService;
    [Inject] private CameraController _cameraController;


    public HeroHolder Holder => _holder;
    public void Initialize()
    {
        _controls.EnableControls(_inputService, _cameraController.MainCamera);
        interactor.SetHero(this);
    }

    private void OnDestroy()
    {
        _controls.DisableControls();
    }
}