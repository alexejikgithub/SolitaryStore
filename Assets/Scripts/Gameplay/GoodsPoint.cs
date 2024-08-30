using UnityEngine;

public class GoodsPoint : MonoBehaviour
{
    private Good _good;

    public void AddGood(Good good)
    {
        _good = good;
        _good.transform.position = transform.position;
        _good.Enable();
    }

    public Good RemoveGood()
    {
        _good.Disable();
        return _good;
    }
}