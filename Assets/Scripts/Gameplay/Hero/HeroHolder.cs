using UnityEngine;

public class HeroHolder : MonoBehaviour
{
    [SerializeField] private Transform _holdPoint;

    private IHoldable _currentHeld;
    public bool IsHolding=> _currentHeld != null;

    public IHoldable CurrentHeld => _currentHeld;

    public void TryHold(IHoldable holdable)
    {
        if(IsHolding)
            return;

        _currentHeld = holdable;
        Hold(_currentHeld);
    }

    public void Hold(IHoldable holdable)
    {
        _currentHeld = holdable;
        
        _currentHeld.BecomeHeld(_holdPoint);
    }

    public void UnHold()
    {
        
    }
}