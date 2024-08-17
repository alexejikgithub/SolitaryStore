using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class LoadSceneState : IPayloadedState<string>
{
    
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IProgressService _progressService;

    // private readonly IGameFactory _gameFactory;
    // private readonly IStaticDataService _staticData;
    // private readonly IUiFactory _uiFactory;


    public LoadSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, ISaveLoadService saveLoadService, IProgressService progressService /* , IGameFactory gameFactory, IPersistantProgressService progressService, IStaticDataService staticData, IUiFactory uiFactory*/)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _saveLoadService = saveLoadService;
        _progressService = progressService;
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
        InformProgressListeners();
    }

    private void InitUiRoot()
    {
       // _uiFactory.CreateUIRoot();
    }

    private void InformProgressListeners()
    {
        foreach (ILoadProgress progressReader in _saveLoadService.LoadProgressesListeners)
        {
            progressReader.LoadProgress(_progressService.StoreProgress);
        }
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