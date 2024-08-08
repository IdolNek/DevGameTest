using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string staticDataEnemies = "GameOption/EnemyData";
        private const string staticDataLevels = "GameOption/Levels";
        private const string staticDataWindows = "GameOption/Windows/WindowsData";
        private const string staticDataPlayer = "GameOption/Player/PlayerData";
        
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemys;
        private Dictionary<EnemyTypeId, EnemySpawnStaticData> _enemysSpawns;
        private Dictionary<int, LevelStaticData> _levels;
        private Dictionary<WindowsId, WindowConfig> _windowConfigs;
        private PlayerStaticData _playerConfig;

        public PlayerStaticData PlayerConfig => _playerConfig; 

        public void LoadStaticData()
        {
            _enemys = Resources.LoadAll<EnemyStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _enemysSpawns = Resources.LoadAll<EnemySpawnStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _levels = Resources
                .LoadAll<LevelStaticData>(staticDataLevels)
                .ToDictionary(x => x.LevelNumber, x => x);
            _windowConfigs = Resources
                .Load<WindowsStaticData>(staticDataWindows)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
            _playerConfig = Resources.Load<PlayerStaticData>(staticDataPlayer);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) =>
            _enemys.TryGetValue(typeId, out EnemyStaticData staticData)
                ? staticData
                : null;
        public EnemySpawnStaticData ForSpawn(EnemyTypeId typeId) =>
            _enemysSpawns.TryGetValue(typeId, out EnemySpawnStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData GetLevel(int levelIndex) =>
            _levels.TryGetValue(levelIndex, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowConfig GetWindow(WindowsId windowsId) =>
            _windowConfigs.TryGetValue(windowsId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}