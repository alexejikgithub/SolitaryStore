using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoreItemsData
{
    [SerializeField] private List<RackData> _purchasedRacks;

    public List<RackData> PurchasedRacks => _purchasedRacks;

    public StoreItemsData()
    {
        _purchasedRacks = new List<RackData>();
    }

    public void SetPurchasedRacks(List<RackData> purchasedRacks)
    {
        _purchasedRacks = purchasedRacks;
    }

    public bool TryGetRackDataByType(GoodType type, out RackData rackData)
    {
        bool isDataExist =false;
        rackData = null;
        foreach (var rack in _purchasedRacks)
        {
            if (rack.Type == type)
            {
                rackData = rack;
                isDataExist = true;
                return isDataExist;
            }
        }

        return isDataExist;
    }
}