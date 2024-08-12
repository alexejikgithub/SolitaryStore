using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputService>().AsSingle().NonLazy();
    }
}
