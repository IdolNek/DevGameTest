using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.Infrastructure.GameOption.DangerZone;
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
        private const string staticDataDangerZones = "GameOption/DangerZone";
        
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemys;
        private Dictionary<int, LevelStaticData> _levels;
        private Dictionary<WindowsId, WindowConfig> _windowConfigs;
        private PlayerStaticData _playerConfig;
        private Dictionary<ZoneType, ZoneData> _zoneConfigs;

        public PlayerStaticData PlayerConfig => _playerConfig;

        public Dictionary<ZoneType, ZoneData> ZoneConfigs => _zoneConfigs;

        public void LoadStaticData()
        {
            _enemys = Resources.LoadAll<EnemyStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _levels = Resources
                .LoadAll<LevelStaticData>(staticDataLevels)
                .ToDictionary(x => x.LevelNumber, x => x);
            _zoneConfigs = Resources
                .LoadAll<ZoneStaticData>(staticDataDangerZones)
                .ToDictionary(x => x.ZoneType, x => x.ZoneData);
            _windowConfigs = Resources
                .Load<WindowsStaticData>(staticDataWindows)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
            _playerConfig = Resources.Load<PlayerStaticData>(staticDataPlayer);
        }

        public EnemyStaticData GetEnemy(EnemyTypeId typeId) =>
            _enemys.TryGetValue(typeId, out EnemyStaticData staticData)
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