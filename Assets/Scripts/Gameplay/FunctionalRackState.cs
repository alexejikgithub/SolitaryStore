public class FunctionalRackState : RackState
{
    private Rack _rack;
    private FunctionalRack _functionalRack;
    
    public FunctionalRackState(Rack rack, FunctionalRack functionalRack)
    {
        _rack = rack;
        _functionalRack = functionalRack;
    }
    public override void Initialize(IProgressService _progress)
    {
        if (_progress.StoreProgress.StoreItemsData.TryGetRackDataByType(_rack.RackData.Type, out RackData rackData))
        {
            for (int i = 0; i < rackData.ItemsAmount; i++)
            {
                _functionalRack.AddGood();
            }
        }
    }

    public override void Highlight(Hero hero)
    {
        if (hero.Holder.IsHolding)
        {
            _functionalRack.HighlightPositive();
        }
        else
        {
            _functionalRack.HighlightNegative();
        }
    }

    public override void UnHighlight(Hero hero)
    {
        _functionalRack.UnHighlight();
    }

    public override void Interact(Hero hero)
    {
        //todo Add check For Good
        //todo Add check For maximum goods

        if (hero.Holder.CurrentHeld is Crate crate && crate.GoodType == _rack.RackData.Type)
        {
            _functionalRack.AddGood();
            _rack.RackData.SetItemsAmount(_rack.RackData.ItemsAmount + 1);
        }
    }
    public override void Enter()
    {
        _functionalRack.Enable();
    }
    public override void Exit()
    {
        _functionalRack.Disable();
    }

    
}