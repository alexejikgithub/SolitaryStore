using System;
using UnityEngine;
using Zenject;

public class RackBase : MonoBehaviour, IInteractable
{
    public event Action<RackTypes, float> Purchased;

    [SerializeField] private RackTypes _rackType;
    [SerializeField] private float _price;
    [SerializeField] private SpriteRenderer _rackOutline;
    [SerializeField] private SpriteRenderer _rack; // ToDoRemove

    [Space] [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _allowedPurchaseColor;
    [SerializeField] private Color _deniedPurchaseColor;

    [Inject] private IProgressService _progress;

    public RackTypes RackType => _rackType;
    public float Price => _price;

    private bool _isEnabled;

    private void Start()
    {
        ShowDefaultColor();
    }

    public void Highlight()
    {
        if (_isEnabled)
            return;

        if (_price < _progress.StoreProgress.MoneyData.MoneyAmount)
        {
            ShowPurchaseAllowed();
        }
        else
        {
            ShowPurchaseDenied();
        }
    }

    public void UnHighlight()
    {
        if (_isEnabled)
            return;
        ShowDefaultColor();
    }

    [ContextMenu("Interact")]
    public void Interact()
    {
        if (_isEnabled)
            return;

        PurchaseRack();
    }

    public void PurchaseRack()
    {
        if (_isEnabled)
            return;

        if (_price > _progress.StoreProgress.MoneyData.MoneyAmount)
            return;

        EnableRack();

        Purchased?.Invoke(RackType,_price);
    }

    public void EnableRack()
    {
        _isEnabled = true;

        _rackOutline.gameObject.SetActive(false);
        _rack.gameObject.SetActive(true);
    }
    

    public void ShowDefaultColor()
    {
        _rackOutline.color = _defaultColor;
    }

    public void ShowPurchaseAllowed()
    {
        _rackOutline.color = _allowedPurchaseColor;
    }

    public void ShowPurchaseDenied()
    {
        _rackOutline.color = _deniedPurchaseColor;
    }
}