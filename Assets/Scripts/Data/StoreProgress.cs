using System;
using UnityEngine;

[Serializable]
public class StoreProgress
{
    [SerializeField] private RacksData _racksData;
    [SerializeField] private MoneyData _moneyData;


    public RacksData RacksData => _racksData;
    public MoneyData MoneyData => _moneyData;

    public StoreProgress()
    {
        _racksData = new RacksData();
        _moneyData = new MoneyData();
    }
}