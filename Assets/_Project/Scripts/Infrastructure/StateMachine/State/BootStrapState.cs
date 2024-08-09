using Assets.Scripts.Infrastructure;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.ServiceLocater;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.UI.Factory;

namespace _Project.Scripts.Infrastructure.StateMachine.State
{
    public class BootStrapState : IState
    {
        private const string InitialScene = "InitialScene";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootStrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<FirstMenuState>();
        }

        private void RegisterServices()
        {
            RegisterInputService();
            RegisterStaticData();
            RegisterAssetService();
            RegisterProgressService();
            RegisterUiFactory();
            RegisterGameFactory();
            RegisterDangerZoneGenerator();
        }

        private void RegisterDangerZoneGenerator()
        {
            
        }


        private void RegisterGameFactory() =>
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(_allServices.Single<IAssetService>()
                , _allServices.Single<IStaticDataService>(), _allServices.Single<IProgressService>()
                , _allServices.Single<IInputService>()
                , _allServices.Single<IUIFactory>(), _stateMachine));

        private void RegisterUiFactory() =>
            _allServices.RegisterSingle<IUIFactory>(new UIFactory(_allServices.Single<IAssetService>()
                , _allServices.Single<IStaticDataService>(), _stateMachine, _allServices.Single<IProgressService>()));

        private void RegisterProgressService()
        {
            _allServices.RegisterSingle<IProgressService>(new ProgressService());
        }

        private void RegisterAssetService() =>
            _allServices.RegisterSingle<IAssetService>(new AssetService());

        private void RegisterInputService() =>
            _allServices.RegisterSingle<IInputService>(new InputService());

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadStaticData();
            _allServices.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}