using _Project.Scripts.Infrastructure.StateMachine.State;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Assets.Scripts.UI.HUD
{
    public class HUDPresenter : MonoBehaviour
    {
        [SerializeField] private InteractButton _interactButton;
        [SerializeField] private ScorePanel _scorePanel;
        private IProgressService _progressService;
        private GameStateMachine _gameStateMachine;

        public void Construct(IProgressService progressService, GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
        }

        public void Initialize()
        {
            _interactButton.OnClick += ExitButtonClicked;
            _progressService.ScoreChanged += OnScoreChanged;
        }

        private void ExitButtonClicked() => 
            _gameStateMachine.Enter<GameOverState>();

        private void OnScoreChanged(int currentScore) => 
            _scorePanel.SetScore(currentScore);
    }
}