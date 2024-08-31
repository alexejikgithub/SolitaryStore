using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Rack : MonoBehaviour, IInteractable
{
    public event Action<RackData, float> Purchased;

    [SerializeField] private UniqueId _uniqueId;
    [SerializeField] private RackData _rackData;
    [SerializeField] private float _price;
    [SerializeField] private RackZone _rackZone;
    [SerializeField] private FunctionalRack _functionalRack;
    [SerializeField] private Collider2D _collider;


    [Inject] private IProgressService _progress;

    public RackData RackData => _rackData;
    public float Price => _price;

    private bool _isEnabled;

    private RackState _activeState;
    private UnpurchasedRackState _unpurchasedRackState;
    private FunctionalRackState _functionalRackState;

// TODO move to editor
    private void OnValidate()
    {
        _rackData.SetId(_uniqueId.Id);
    }

    public void Initialize()
    {
        _unpurchasedRackState = new UnpurchasedRackState(this, _rackZone, _progress);
        _functionalRackState = new FunctionalRackState(this, _functionalRack);
        _activeState = _unpurchasedRackState;
    }

    public void Highlight(Hero hero)
    {
        _activeState.Highlight(hero);
    }

    public void UnHighlight(Hero hero)
    {
        _activeState.UnHighlight(hero);
    }

    public void Interact(Hero hero)
    {
        _activeState.Interact(hero);
    }

    public void TryPurchaseRack()
    {
        if (_price > _progress.StoreProgress.MoneyData.MoneyAmount)
            return;
        SetFunctional();
        Purchased?.Invoke(RackData, _price);
    }

    public void SetUnpurchased()
    {
        SetState(_unpurchasedRackState);
    }

    public void SetFunctional()
    {
        SetState(_functionalRackState);
        StartCoroutine(ResetCollider());
    }

    private void SetState(RackState newState)
    {
        _activeState?.Exit();
        _activeState = newState;
        _activeState.Enter();
        _activeState.Initialize(_progress);
    }

    private IEnumerator ResetCollider()
    {
        _collider.enabled = false;
        yield return new WaitForEndOfFrame();
        _collider.enabled = true;
    }
}