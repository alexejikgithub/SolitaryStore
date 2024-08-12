using System.Collections.Generic;
using UnityEngine;

public class HeroInteraction : MonoBehaviour
{
    [SerializeField] private Cursor _cursor;

    private IInputService _inputService;
    private List<IInteractable> _interactables = new List<IInteractable>();
    private IInteractable _currentInteractable;
    

    public void EnableInteraction(IInputService inputService, Camera mainCamera)
    {

        _inputService = inputService;
        _cursor.Enable(inputService, mainCamera);
        
        _cursor.CursorPoint.TriggerEnter += OnCursorTriggerEnter;
        _cursor.CursorPoint.TriggerExit += OnCursorTriggerExit;
    }

    public void DisableInteraction()
    {
        _cursor.Disable();
        
        _cursor.CursorPoint.TriggerEnter -= OnCursorTriggerEnter;
        _cursor.CursorPoint.TriggerExit -= OnCursorTriggerExit;
    }
    
    
    private void OnCursorTriggerEnter(Collider2D collider)
    {
        if (!collider.TryGetComponent(out RackBase rackBase))
            return;

        TryUnhighlightCurrentInteractable();
        HighlightInteractable(rackBase);
        _interactables.Add(rackBase);
        _currentInteractable = rackBase;
    }

    public void OnCursorTriggerExit(Collider2D collider)
    {
        if (!collider.TryGetComponent(out IInteractable rackBase))
            return;

        if (!_interactables.Contains(rackBase))
            return;

        _interactables.Remove(rackBase);
        TryHighlightPreviousInteractable(rackBase);
    }

    private void TryUnhighlightCurrentInteractable()
    {
        if (_currentInteractable == null)
            return;

        UnHiglightInteractable(_currentInteractable);
        _currentInteractable = null;
    }

    private void TryHighlightPreviousInteractable(IInteractable exitedInteractable)
    {
        if (_currentInteractable != exitedInteractable)
            return;

        UnHiglightInteractable(_currentInteractable);

        if (_interactables.Count > 0)
        {
            _currentInteractable = _interactables[^1];
            HighlightInteractable(_currentInteractable);
        }
        else
        {
            _currentInteractable = null;
        }
    }

    private void HighlightInteractable(IInteractable rackBase)
    {
        rackBase.Highlight();
    }

    public void UnHiglightInteractable(IInteractable rackBase)
    {
        rackBase.UnHighlight();
    }
}