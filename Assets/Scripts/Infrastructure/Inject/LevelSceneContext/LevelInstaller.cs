using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private CameraController _cameraController;

    public override void InstallBindings()
    {
        InstallLevelManager();
        InstallCameraController();
    }

    private void InstallLevelManager()
    {
        Container.Bind<LevelManager>().FromInstance(_levelManager).AsSingle().NonLazy();
    }

    private void InstallCameraController()
    {
        Container.Bind<CameraController>().FromInstance(_cameraController).AsSingle().NonLazy();
    }
}