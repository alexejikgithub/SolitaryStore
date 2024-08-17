using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
  [Inject] private GameStateMachine _gameStateMachine;

  private void Awake()
  {
    _gameStateMachine.Enter<BootstrapState>();
  }
}