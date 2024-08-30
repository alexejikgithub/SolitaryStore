using UnityEngine;

public interface IHoldable :IHighlightable
{
    void BecomeHeld(Transform holdPoint);
    void BecomeUnHeld();
}