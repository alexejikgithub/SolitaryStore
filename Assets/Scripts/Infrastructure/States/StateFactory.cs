using UnityEngine;
using Zenject;

public class StateFactory : IStateFactory
{
    private readonly DiContainer _container;

    public StateFactory(DiContainer container)
    {
        _container = container;
    }

    public T Create<T>() where T : IExitableState
    {
        Debug.Log(_container);
        return _container.Instantiate<T>();
    }
}