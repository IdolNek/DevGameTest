using _Project.Scripts.Infrastructure.StateMachine.State;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class FirstMenuPresenter:MonoBehaviour
    {
        [SerializeField] private InteractButton _interactButton;
        [SerializeField] private ScorePanel _scorePanel;
        
        private GameStateMachine _stateMachine;
        private IStaticDataService _staticDataService;
        private IProgressService _progressService;

        public void Construct(GameStateMachine stateMachine, IStaticDataService staticDataService, IProgressService progressService)
        {
            _progressService = progressService;
            _staticDataService = staticDataService;
            _stateMachine = stateMachine;
        }
        public void Initialize(float score)
        {
            _scorePanel.SetScore(score);
            _interactButton.OnClick += InteractButtonClicked;
        }

        private void InteractButtonClicked()
        {
            string level = _staticDataService.GetLevel(_progressService.CurrentLevel).LevelKey;
            _stateMachine.Enter<LoadLevelState, string>(level);
            Destroy(gameObject);
        }

        private void OnDisable() => 
            _interactButton.OnClick -= InteractButtonClicked;
    }
}