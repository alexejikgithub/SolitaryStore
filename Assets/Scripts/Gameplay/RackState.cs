public abstract class RackState : IState
{

    public virtual void Initialize(IProgressService _progress)
    {
        
    }
    public virtual void Highlight(Hero hero)
    {
    }

    public virtual void UnHighlight(Hero hero)
    {
    }

    public virtual void Interact(Hero hero)
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Enter()
    {
    }
}