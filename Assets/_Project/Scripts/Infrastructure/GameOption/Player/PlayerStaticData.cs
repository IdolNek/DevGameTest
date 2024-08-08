using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/Player")]
    public class PlayerStaticData : ScriptableObject
    {
        [Range(1, 100)]
        public int Hp;
        [Range(1, 30)]
        public float MoveSpeed;
        [Range(0.1f, 360)]
        public float RotationSpeed;
        
        public GameObject PlayerPrefab;
    }
}
