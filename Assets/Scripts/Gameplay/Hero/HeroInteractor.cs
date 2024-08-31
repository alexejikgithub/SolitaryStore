using System.Collections.Generic;
using UnityEngine;

public class HeroInteractor : MonoBehaviour
{
    [SerializeField] private Cursor _cursor;

    private IInputService _inputService;
    private List<IHighlightable> _highlightables = new List<IHighlightable>();
    private IHighlightable _currentHiglighted;
    private Hero _hero;


    public void EnableInteraction(IInputService inputService, Camera mainCamera)
    {
        _inputService = inputService;
        _cursor.Enable(inputService, mainCamera);

        _cursor.CursorPoint.TriggerEnter += OnCursorTriggerEnter;
        _cursor.CursorPoint.TriggerExit += OnCursorTriggerExit;
        _inputService.CurrentInput.InteractPressed += TryInteract;
    }

    public void DisableInteraction()
    {
        _cursor.Disable();

        _cursor.CursorPoint.TriggerEnter -= OnCursorTriggerEnter;
        _cursor.CursorPoint.TriggerExit -= OnCursorTriggerExit;
        _inputService.CurrentInput.InteractPressed -= TryInteract;
    }

    private void OnCursorTriggerEnter(Collider2D collider)
    {
        if (!collider.TryGetComponent(out IHighlightable highlightable))
            return;
        
        TryUnhighlightCurrentInteractable();
        HighlightInteractable(highlightable);
        _highlightables.Add(highlightable);
        _currentHiglighted = highlightable;
    }

    public void OnCursorTriggerExit(Collider2D collider)
    {
        if (!collider.TryGetComponent(out IHighlightable highlightable))
            return;

        if (!_highlightables.Contains(highlightable))
            return;

        _highlightables.Remove(highlightable);
        TryHighlightPreviousInteractable(highlightable);
    }

    private void TryUnhighlightCurrentInteractable()
    {
        if (_currentHiglighted == null)
            return;

        UnHiglightInteractable(_currentHiglighted);
        _currentHiglighted = null;
    }

    private void TryHighlightPreviousInteractable(IHighlightable exitedInteractable)
    {
        if (_currentHiglighted != exitedInteractable)
            return;

        UnHiglightInteractable(_currentHiglighted);

        if (_highlightables.Count > 0)
        {
            _currentHiglighted = _highlightables[^1];
            HighlightInteractable(_currentHiglighted);
        }
        else
        {
            _currentHiglighted = null;
        }
    }

    private void HighlightInteractable(IHighlightable highlightable)
    {
        highlightable.Highlight(_hero);
    }

    public void UnHiglightInteractable(IHighlightable highlightable)
    {
        highlightable.UnHighlight(_hero);
    }

    public void TryInteract()
    {
        
        
        if (_currentHiglighted == null)
        {
            if (_hero.Holder.IsHolding && _cursor.IsOverNavMesh())
            {
                _hero.Holder.UnHold(_cursor.CursorPoint.transform.position);
            }
            return;
        }
        
        switch (_currentHiglighted)
        {
            case IInteractable interactable:
                interactable.Interact(_hero);
                break;
            case IHoldable holdable:
                _hero.Holder.TryHold(holdable);
                break;
        }
    }

    public void SetHero(Hero hero)
    {
        _hero = hero;
    }
}