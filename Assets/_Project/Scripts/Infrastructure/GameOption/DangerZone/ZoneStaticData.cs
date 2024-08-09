using UnityEngine;

namespace _Project.Scripts.Infrastructure.GameOption.DangerZone
{
    [CreateAssetMenu(fileName = "DangerZoneData", menuName = "StaticData/DangerZone")]
    public class ZoneStaticData : ScriptableObject
    {
        public ZoneType ZoneType;
        public ZoneData ZoneData;
    }
}