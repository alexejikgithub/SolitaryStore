using System;
using UnityEngine;

[Serializable]
public class RackData
{
    [SerializeField] private string _id;
    [SerializeField] private GoodType _type;
    [SerializeField] private int _itemsAmount;

    public string ID => _id;

    public GoodType Type => _type;

    public int ItemsAmount => _itemsAmount;

    public void SetId(string id)
    {
        _id = id;
    }

    public void SetItemsAmount(int amount)
    {
        _itemsAmount = amount;
    }
}