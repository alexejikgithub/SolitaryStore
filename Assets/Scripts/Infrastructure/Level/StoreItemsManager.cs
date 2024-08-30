using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class StoreItemsManager : MonoBehaviour
{
    [SerializeField] private List<Rack> _allRacks;
    [Inject] private IProgressService _progress;
    
    private List<RackData> _purchasedRacks;

    private void OnEnable()
    {
        UpdateProgress();
        foreach (var rack in _allRacks)
        {
            rack.Purchased += OnRackPurchased;
        }
    }

    private void OnDisable()
    {
        foreach (var rack in _allRacks)
        {
            rack.Purchased -= OnRackPurchased;
        }
    }

    private void UpdateProgress()
    {
        _purchasedRacks = _progress.StoreProgress.StoreItemsData.PurchasedRacks;
        InitializeAllRacks();
    }

    private void InitializeAllRacks()
    {
        
        foreach (var rack in _allRacks)
        {
            rack.Initialize();
            
            if (ContainsRackWithId(rack.RackData.ID))
            {
                rack.SetFunctional();
            }
            else
            {
                rack.SetUnpurchased();
            }
        }

    }

    private bool ContainsRackWithId(string idName)
    {
        return _purchasedRacks.Any(rack => rack.ID == idName);
    }

    private void OnRackPurchased(RackData rackType, float price)
    {
        _purchasedRacks.Add(rackType);
        _progress.StoreProgress.StoreItemsData.SetPurchasedRacks(_purchasedRacks);
        _progress.StoreProgress.MoneyData.Remove(price);
    }
}
