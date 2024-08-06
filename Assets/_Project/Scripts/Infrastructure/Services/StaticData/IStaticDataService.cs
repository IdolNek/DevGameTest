﻿using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;


namespace Assets.Scripts.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        PlayerStaticData PlayerConfig { get; }

        void LoadStaticData();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        LevelStaticData GetLevel(int levelIndex);
        WindowConfig GetWindow(WindowsId chooseAbility);
        EnemySpawnStaticData ForSpawn(EnemyTypeId typeId);
    }
}