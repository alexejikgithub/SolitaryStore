using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractableItemsManager : MonoBehaviour , ISaveProgress , ILoadProgress
{
    [SerializeField] private List<RackBase> _allRacks;
    [Inject] private ISaveLoadService _saveLoadService;
    [Inject] private IProgressService _progress;
    
    private List<RackTypes> _purchasedRacks;

    private void OnEnable()
    {
        _saveLoadService.RegisterLoadListener(this);
        _saveLoadService.RegisterSaveListener(this);
        
        foreach (var rack in _allRacks)
        {
            rack.Purchased += OnRackPurchased;
        }
    }

    private void OnDisable()
    {
        _saveLoadService.UnRegisterLoadListener(this);
        _saveLoadService.UnRegisterSaveListener(this);
        
        foreach (var rack in _allRacks)
        {
            rack.Purchased -= OnRackPurchased;
        }
    }

    public void SaveProgress(StoreProgress progress)
    {
        progress.RacksData.SetPurchasedRacks(_purchasedRacks);
    }

    public void LoadProgress(StoreProgress progress)
    {
        _purchasedRacks = progress.RacksData.PurchasedRacks;
        UpdateAllRacks();
    }

    private void UpdateAllRacks()
    {
        foreach (var rack in _allRacks)
        {
            if (_purchasedRacks.Contains(rack.RackType))
            {
                rack.EnableRack();
            }
        }

        foreach (var rackType in _purchasedRacks)
        {
            Debug.Log(rackType);
        }
    }

    private void OnRackPurchased(RackTypes rackType, float price)
    {
        _purchasedRacks.Add(rackType);
        _progress.StoreProgress.MoneyData.Remove(price);
    }
}
