public class UnpurchasedRackState : RackState
{
    private Rack _rack;
    private RackZone _rackZone;
    private IProgressService _progress;

    public UnpurchasedRackState(Rack rack, RackZone rackZone, IProgressService progress)
    {
        _rack = rack;
        _rackZone = rackZone;
        _progress = progress;
    }

    public override void Highlight(Hero hero)
    {
        if (_rack.Price < _progress.StoreProgress.MoneyData.MoneyAmount)
        {
            _rackZone.ShowPurchaseAllowed();
        }
        else
        {
            _rackZone.ShowPurchaseDenied();
        }
    }

    public override void UnHighlight(Hero hero)
    {
        _rackZone.ShowDefaultColor();
    }

    public override void Interact(Hero hero)
    {
        _rack.TryPurchaseRack();
    }
    public override void Enter()
    {
        _rackZone.Enable();
    }
    public override void Exit()
    {
        _rackZone.Disable();
    }

}