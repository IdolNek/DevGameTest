using _Project.Scripts.Character.Player;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.UI.Factory;
using Assets.Scripts.SpawnPool;
using Assets.Scripts.UI.HUD;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {

        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progress;
        private readonly IInputService _inputService;
        private readonly IUIFactory _uIFactory;
        private readonly GameStateMachine _gameStateMachine;
        private GameObject _player;
        private EnemySpawner _spawner;

        public GameObject Player => _player;
        public EnemySpawner Spawner => _spawner;

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IInputService inputService, IUIFactory uIFactory, GameStateMachine gameStateMachine)
        {
            _asset = asset;
            _staticData = staticData;
            _progress = progress;
            _inputService = inputService;
            _uIFactory = uIFactory;
            _gameStateMachine = gameStateMachine;
        }


        public GameObject CreateHero(Vector3 at)
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            _player = Object.Instantiate(playerData.PlayerPrefab, at, Quaternion.identity);
            PlayerMovement playerMovement = _player.GetComponent<PlayerMovement>();
            playerMovement.Construct(_inputService);
            playerMovement.Initialize(playerData.MoveSpeed);
            PlayerAttack playerAttack = _player.GetComponent<PlayerAttack>();
            playerAttack.Construct(_inputService);
            playerAttack.Initialize(playerData.RotationSpeed);
            return _player;
        }
        public void ResetPlayer()
        {

        }

        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            var hudPresenter = hud.GetComponent<HUDPresenter>();
            hudPresenter.Construct(_progress, _gameStateMachine);
            hudPresenter.Initialize();
            return hud;
        }

        public void CreateSpawner(EnemySpawnStaticData enemySpawnerStaticData)
        {
            _spawner = Object.Instantiate(enemySpawnerStaticData.SpawnPrefab).GetComponent<EnemySpawner>();
            _spawner.Construct(this, enemySpawnerStaticData);
            _spawner.Initialize();

        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemydata = _staticData.ForEnemy(enemyTypeId);
            string sceneKey = SceneManager.GetActiveScene().name;
            GameObject enemy = Object.Instantiate(enemydata.EnemyPrefab);
            
            return enemy;
        }        

        

        // public GameObject CreateMoney(Vector3 position)
        // {
        //     var money = _asset.Instantiate(AssetPath.Money, position);
        //     return money;
        // }        
    }
}