using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.EnemySpawner
{
    [CreateAssetMenu(fileName = "EnemySpawnerData", menuName = "StaticData/EnemySpawner")]
    public class EnemySpawnStaticData : ScriptableObject
    {
        [Range(0.1f, 15f)] public float StartTimeBetweenSpawns;
        [Range(0.1f, 15f)] public float ReduceSpawnTime;
        [Range(0.1f, 1f)] public float ReduceSpawningTimeBy;
        [Range(0.1f, 1f)] public float MinTimeBetweenSpawns;
    }
}