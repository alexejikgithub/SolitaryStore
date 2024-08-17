using UnityEngine;
using Zenject;

public class InfrastructureInstaller : MonoInstaller
{
    [SerializeField] private GameBootstrapper _gameBootstrapper;
    [SerializeField] private ProjectCoroutineRunner _projectCoroutineRunner;
    [SerializeField] private LoadingCurtain _loadingCurtain;

    public override void InstallBindings()
    {
        InstallProjectCoroutineRunner();

        InstallLoadingCurtain();

        InstallGameBootstrapper();

        InstallGameStateMachine();
    }

    private void InstallProjectCoroutineRunner()
    {
        Container.Bind<ICoroutineRunner>().FromComponentInNewPrefab(_projectCoroutineRunner).AsSingle().NonLazy();
    }

    private void InstallLoadingCurtain()
    {
        Container.Bind<LoadingCurtain>().FromComponentInNewPrefab(_loadingCurtain).AsSingle().NonLazy();
    }

    private void InstallGameStateMachine()
    {
        Container.Bind<GameStateMachine>().AsSingle();
    }

    private void InstallGameBootstrapper()
    {
        Container.Bind<GameBootstrapper>().FromComponentInNewPrefab(_gameBootstrapper).AsSingle().NonLazy();
    }
}