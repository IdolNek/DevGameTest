using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.EnemyData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        [Range(1, 100)] public int Hp;
        [Range(0.5f, 10)] public float MoveSpeed;
        [Range(0f, 50)] public int Score;
        [Range(0.01f, 100f)] public float SpawnChance;
        public GameObject EnemyPrefab;
    }
}