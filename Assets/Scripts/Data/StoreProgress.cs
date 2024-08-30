using System;
using UnityEngine;

[Serializable]
public class StoreProgress
{
    [SerializeField] private StoreItemsData storeItemsData;
    [SerializeField] private MoneyData _moneyData;


    public StoreItemsData StoreItemsData => storeItemsData;
    public MoneyData MoneyData => _moneyData;

    public StoreProgress()
    {
        storeItemsData = new StoreItemsData();
        _moneyData = new MoneyData();
    }
}