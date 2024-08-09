using System.Collections.Generic;
using _Project.Scripts.Infrastructure.GameOption.DangerZone;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;


namespace Assets.Scripts.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        PlayerStaticData PlayerConfig { get; }
        Dictionary<ZoneType, ZoneData> ZoneConfigs { get; }

        void LoadStaticData();
        EnemyStaticData GetEnemy(EnemyTypeId typeId);
        LevelStaticData GetLevel(int levelIndex);
        WindowConfig GetWindow(WindowsId chooseAbility);
    }
}