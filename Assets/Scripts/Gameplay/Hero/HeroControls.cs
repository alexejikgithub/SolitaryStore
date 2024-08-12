using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControls : MonoBehaviour
{
    [SerializeField] private HeroMovement _heroMovement;
    [SerializeField] private HeroInteraction _heroInteraction;

    private IInputService _inputService;
    
    public void EnableControls(IInputService inputService, Camera mainCamera)
    {
        _heroMovement.EnableMovement(inputService);
        _heroInteraction.EnableInteraction(inputService, mainCamera);
    }

    public void DisableControls()
    {
        _heroMovement.DisableMovement();
        _heroInteraction.DisableInteraction();
    }
}
