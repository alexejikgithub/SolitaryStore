using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RacksData
{
    [SerializeField] private List<RackTypes> _purchasedRacks;

    public List<RackTypes> PurchasedRacks => _purchasedRacks;

    public RacksData()
    {
        _purchasedRacks = new List<RackTypes>();
    }

    public void SetPurchasedRacks(List<RackTypes> purchasedRacks)
    {
        _purchasedRacks = purchasedRacks;
    }
}