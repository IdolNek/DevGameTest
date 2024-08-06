using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.UI.Factory;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public class FirstMenuState : IState
    {
        private const string GameScene = "FirstMenu";
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IUIFactory _uiFactory;

        public FirstMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IUIFactory uiFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _uiFactory = uiFactory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _sceneLoader.Load(GameScene, OnLoaded );
        }
        
        private void OnLoaded()
        {
            _uiFactory.CreateUIRoot();
            _uiFactory.Open(WindowsId.GameMenu);
        }
    }
}