using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
  [Inject] private GameStateMachine _gameStateMachine;

  private void Start()
  {
    _gameStateMachine.Enter<BootstrapState>();
  }
}