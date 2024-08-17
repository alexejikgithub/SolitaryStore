using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counter;

    [Inject] private IProgressService _progress;

    private void Start()
    {
        _progress.StoreProgress.MoneyData.Changed += UpdateCounter;
        UpdateCounter();
    }

    [ContextMenu("AddMoney")]
    public void TestAddMoney()
    {
        _progress.StoreProgress.MoneyData.Add(50f);
    }

    private void UpdateCounter()
    {
            
        _counter.text = $"{_progress.StoreProgress.MoneyData.MoneyAmount}";
    }

    
}
