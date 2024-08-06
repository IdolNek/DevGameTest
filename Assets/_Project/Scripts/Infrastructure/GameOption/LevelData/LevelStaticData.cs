using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public int LevelNumber;
        public string LevelKey;
        public Vector3 StartPlayerPoint;
    }
}