using System;
using UnityEngine;

[Serializable]
public class MoneyData
{
    public Action Changed;

    [SerializeField] private float _moneyAmount;

    public float MoneyAmount => _moneyAmount;


    public void Add(float value)
    {
        _moneyAmount += value;
        Changed?.Invoke();
    }

    public void Remove(float value)
    {
        _moneyAmount -= value;
        Changed?.Invoke();
    }
}