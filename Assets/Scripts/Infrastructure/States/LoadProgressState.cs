using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    private readonly IInputService _inputService;
    private readonly IProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    private string _startLevelName = "MainMenu";
    
    public LoadProgressState(GameStateMachine gameStateMachine, IInputService inputService, ISaveLoadService saveLoadService,  IProgressService progressService)
    {
        _gameStateMachine = gameStateMachine;
        _inputService = inputService;
        _saveLoadService = saveLoadService;
        _progressService = progressService;
        
    }

    public void Enter()
    {
        TryLoadProgress();
        _gameStateMachine.Enter<LoadSceneState, string>(_startLevelName);
    }


    public void Exit()
    {
    }
    private void TryLoadProgress()
    {
        _progressService.StoreProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        
        _inputService.SetCurrentInput(InputType.NewInputSystem);  //TODO Move somewhere else??
        
    }

    private StoreProgress NewProgress()
    {
        var progress = new StoreProgress();

        return progress;
    }
}