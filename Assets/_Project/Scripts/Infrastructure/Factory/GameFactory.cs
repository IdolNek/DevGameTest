using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
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
        private GameObject _player;
        private EnemySpawner _spawner;

        public GameObject Player => _player;
        public EnemySpawner Spawner => _spawner;

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IInputService inputService, IUIFactory uIFactory)
        {
            _asset = asset;
            _staticData = staticData;
            _progress = progress;
            _inputService = inputService;
            _uIFactory = uIFactory;
        }


        public GameObject CreateHero(Vector3 at)
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            
            return _player;
        }
        public void ResetPlayer()
        {

        }

        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            var hudPresenter = hud.GetComponent<HUDPresenter>();
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

        public GameObject CreateBullet()
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            GameObject bullet = Object.Instantiate(playerData.BulletPrefab);
            return bullet;
        }

        // public GameObject CreateMoney(Vector3 position)
        // {
        //     var money = _asset.Instantiate(AssetPath.Money, position);
        //     return money;
        // }        
    }
}