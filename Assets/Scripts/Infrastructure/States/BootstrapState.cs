using System;

public class BootstrapState : IState
{
    private const string Initial = "Initial";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;

    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;

        RegisterServices();
    }

    public void Enter()
    {
        _sceneLoader.Load(Initial, onLoaded: EnterLoadScene);
    }

    private void EnterLoadScene()
    {
        _stateMachine.Enter<LoadProgressState>();
    }

    private void RegisterServices()
    {
 
    }

   

    public void Exit()
    {
    }
    
}