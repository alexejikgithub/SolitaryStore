using UnityEngine;

public class HeroControls : MonoBehaviour
{
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private HeroInteractor heroInteractor;

    private IInputService _inputService;
    
    public void EnableControls(IInputService inputService, Camera mainCamera)
    {
        _heroMovement.EnableMovement(inputService);
        heroInteractor.EnableInteraction(inputService, mainCamera);
    }

    public void DisableControls()
    {
        _heroMovement.DisableMovement();
        heroInteractor.DisableInteraction();
    }
}
