using System;
using UnityEngine;
using Zenject;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform _heroSpawnPoint;
    [SerializeField] private Hero _heroprefab;

    [Inject] private ISaveLoadService _saveLoadService;
    
    private Hero _hero;


    private void Start()
    {
        InitializeScene();
    }
    

    private void InitializeScene()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        _hero = Instantiate(_heroprefab);
        _hero.transform.position = _heroSpawnPoint.position;
        _hero.transform.localEulerAngles = Vector3.zero;
        _hero.transform.parent = transform;
        
        _hero.Initialize();
    }
    
    [ContextMenu("SaveLevel")]
    public void SaveLevel()
    {
        _saveLoadService.SaveProgress();
    }
}