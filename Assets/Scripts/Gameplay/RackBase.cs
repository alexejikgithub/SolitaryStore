using UnityEngine;

public class RackBase : MonoBehaviour, IInteractable
{
    [SerializeField] private SpriteRenderer _rackOutline;
    [SerializeField] private SpriteRenderer _rack; // ToDoRemove

    [Space] [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _allowedPurchaseColor;
    [SerializeField] private Color _deniedPurchaseColor;

    private void Start()
    {
        ShowDefaultColor();
    }
    
    public void Highlight()
    {
        ShowPurchaseAllowed();
    }

    public void UnHighlight()
    {
        ShowDefaultColor();
    }

    public void Interact()
    {
        PurchaseRack();
    }

    public void PurchaseRack()
    {
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