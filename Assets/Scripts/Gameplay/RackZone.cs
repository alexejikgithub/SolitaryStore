using UnityEngine;

public class RackZone : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rackOutline;

    [Space] [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _allowedPurchaseColor;
    [SerializeField] private Color _deniedPurchaseColor;

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

    public void Enable()
    {
        gameObject.SetActive(true);
        ShowDefaultColor();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}