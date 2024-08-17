using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputService>().AsSingle().NonLazy();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle().NonLazy();
        Container.Bind<IProgressService>().To<ProgressService>().AsSingle().NonLazy();
    }
}
