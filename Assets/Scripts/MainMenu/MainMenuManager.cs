using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    
    private string _levelName = "SampleScene";
    
    [Inject] private GameStateMachine _gameStateMachine;

    
    private void Awake()
    {
        _startGameButton.onClick.AddListener(GoToFirstLevel);
    }
    private void OnDestroy()
    {
        _startGameButton.onClick.RemoveListener(GoToFirstLevel);
    }
    
    private void GoToFirstLevel()
    {
        _gameStateMachine.Enter<LoadSceneState, string>(_levelName);
    }

}
