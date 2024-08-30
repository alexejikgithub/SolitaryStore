using System.Collections.Generic;
using UnityEngine;

public class FunctionalRack : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rack;
    [SerializeField] private List<GoodsPoint> _goodsPoints;
    [SerializeField] private List<Good> _goodsPool;
    [SerializeField] private OutlineFx.OutlineFx _outline;
    
    
    private List<GoodsPoint> _vacantGoodsPoints = new List<GoodsPoint>();
    private List<GoodsPoint> _occupiedGoodsPoints = new List<GoodsPoint>();

    private List<Good> _vacantGoods;
    
    public void AddGood()
    {
        if(_vacantGoodsPoints.Count<=0|| _vacantGoods.Count<=0)
            return;
        
        GoodsPoint currentPoint = _vacantGoodsPoints[^1];
        _vacantGoodsPoints.Remove(currentPoint);
        _occupiedGoodsPoints.Add(currentPoint);

        Good good = _vacantGoods[^1];
        _vacantGoods.Remove(good);
        
        currentPoint.AddGood(good);
    }

    public void RemoveGood()
    {
        if(_occupiedGoodsPoints.Count<=0)
            return;
        
        GoodsPoint currentPoint = _occupiedGoodsPoints[^1];
        _vacantGoodsPoints.Remove(currentPoint);
        _occupiedGoodsPoints.Add(currentPoint);

        Good good = currentPoint.RemoveGood();
        _vacantGoods.Add(good);
    }

    public void HighlightPositive()
    {
        _outline.enabled = true;
        _outline.Color = Color.green;

    }

    public void HighlightNegative()
    {
        _outline.enabled = true;
        _outline.Color = Color.red;
    }

    public void UnHighlight()
    {
        _outline.enabled = false;
    }
    

    public void Enable()
    {
        _vacantGoodsPoints = _goodsPoints;
        _vacantGoods = _goodsPool;
        
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        for (var index = 0; index < _occupiedGoodsPoints.Count; index++)
        {
            RemoveGood();
        }

        gameObject.SetActive(false);
    }


}