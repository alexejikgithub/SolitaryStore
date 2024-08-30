using DG.Tweening;
using UnityEngine;

public class Crate : MonoBehaviour, IHoldable
{
    [SerializeField] private GoodType _goodType;
    [SerializeField] private int _goodCount;
    [SerializeField] private SpriteRenderer _renderer;
    
    [SerializeField] private OutlineFx.OutlineFx _outline;

    private float _moveTime = 0.3f;

    private int _heldLayerIndex =5;
    private int _defaultLayerIndex;

    public GoodType GoodType => _goodType;
    public void Highlight(Hero hero)
    {
        _outline.enabled = true;
        if (hero.Holder.IsHolding)
        {
            _outline.Color = Color.red; 
        }
        else
        {
            _outline.Color = Color.green;
        }
    }

    public void UnHighlight(Hero hero)
    {
        _outline.enabled = false;
    }


    public void BecomeHeld(Transform holdPoint)
    {
        _defaultLayerIndex = _renderer.sortingOrder;
        _renderer.sortingOrder = _heldLayerIndex;
        
        transform.parent = holdPoint;
        transform.DOLocalMove(Vector3.zero, _moveTime);
    }

    public void BecomeUnHeld()
    {
    }
}