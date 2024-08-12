﻿using System;
using UnityEngine;
using Zenject;

public class LoadSceneState : IPayloadedState<string>
{
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    // private readonly IGameFactory _gameFactory;
    // private readonly IPersistantProgressService _progressService;
    // private readonly IStaticDataService _staticData;
    // private readonly IUiFactory _uiFactory;


    public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain /* , IGameFactory gameFactory, IPersistantProgressService progressService, IStaticDataService staticData, IUiFactory uiFactory*/)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        // _gameFactory = gameFactory;
        // _progressService = progressService;
        // _staticData = staticData;
        // _uiFactory = uiFactory;
    }

    public void Enter(string sceneName)
    {
        _curtain.Show();
        //_gameFactory.Cleanup();
        _sceneLoader.Load(sceneName, OnLoaded);
    }
        
    public void Exit()
    {
        _curtain.Hide();
    }

    private void OnLoaded()
    {
        // InitUiRoot();
        // InitGameWorld();
        // InformProgressReaders();

        _stateMachine.Enter<GameLoopState>();
    }

    private void InitUiRoot()
    {
       // _uiFactory.CreateUIRoot();
    }

    private void InformProgressReaders()
    {
        // foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        // {
        //     progressReader.LoadProgress(_progressService.PlayerProgress);
        // }
    }

    private void InitHud(GameObject hero)
    {
        // GameObject hud = _gameFactory.CreateHud();
        // hud.GetComponentInChildren<ActorUI>().Construct(hero.GetComponent<HeroHealth>());
    }

    // private void InitGameWorld()
    // {
    //     var levelData = GetLevelStaticData();
    //
    //     InitSpawners(levelData);
    //     GameObject hero = _gameFactory.CreateHero(levelData);
    //     StartCameraFollow(hero);
    //     InitHud(hero);
    // }
    //
    // private LevelStaticData GetLevelStaticData()
    // {
    //     string sceneKey = SceneManager.GetActiveScene().name;
    //     LevelStaticData levelData = _staticData.ForLevel(sceneKey);
    //     return levelData;
    // }
    //
    // private void InitSpawners(LevelStaticData levelData)
    // {
			 //
    //     foreach (var enemySpawnerData in levelData.EnemySpawners)
    //     {
    //         _gameFactory.CreateSpawner(enemySpawnerData.Position, enemySpawnerData.Id,
    //             enemySpawnerData.EnemyTypeId);
    //     }
    // }
    //
    // private void StartCameraFollow(GameObject hero)
    // {
    //     Camera.main.GetComponent<CameraFollow>().Follow(hero);
    // }
}