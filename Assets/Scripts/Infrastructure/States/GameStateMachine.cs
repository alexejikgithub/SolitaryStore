using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine
{
    private Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;
    
    public GameStateMachine(DiContainer diContainer)
    {
        var sceneLoader = new SceneLoader(diContainer.Resolve<ICoroutineRunner>());
        _states = new Dictionary<Type, IExitableState>()
        {
            [typeof(BootstrapState)] = new BootstrapState(this,sceneLoader),
            [typeof(LoadProgressState)] = new LoadProgressState(this,diContainer.Resolve<IInputService>()),
            [typeof(LoadSceneState)] = new LoadSceneState(this,sceneLoader,diContainer.Resolve<LoadingCurtain>()),
            [typeof(GameLoopState)] = new GameLoopState(this)
        };
    }
    
    public void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }
    
    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
        TState state = ChangeState<TState>();
        state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();
        TState state = GetState<TState>();
        _activeState = state;
        return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState => _states[typeof(TState)] as TState;
   
}