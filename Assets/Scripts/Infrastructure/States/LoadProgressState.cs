using System;
using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    private readonly IInputService _inputService;
    // private readonly IPersistantProgressService _progressService;
    // private readonly ISaveLoadService _saveLoadService;

    private string _startLevelName = "MainMenu";
    
    public LoadProgressState(GameStateMachine gameStateMachine, IInputService inputService /* ,IPersistantProgressService progressService, ISaveLoadService saveLoadService */)
    {
        _gameStateMachine = gameStateMachine;
        _inputService = inputService;
        // _progressService = progressService;
        // _saveLoadService = saveLoadService;
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
        // _progressService.PlayerProgress = _saveLoadService.LoadProgress() ?? NewProgress();
        _inputService.SetCurrentInput(InputType.KeyboardAndMouse);
        
    }

    // private PlayerProgress NewProgress()
    // {
    //     var progress = new PlayerProgress(initialLevel: "Main");
    //
    //     progress.HeroState.MaxHP = 50;
    //     progress.HeroState.ResetHP();
    //     progress.HeroStats.Damage = 1f;
    //     progress.HeroStats.DamageRadius = 1f;
			 //
    //     return progress;
    // }
}