﻿using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.SpawnPool;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        void ResetPlayer();
    }
}