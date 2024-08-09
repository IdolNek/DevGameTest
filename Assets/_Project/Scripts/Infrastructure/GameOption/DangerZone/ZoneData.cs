using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.GameOption.DangerZone
{
    [Serializable]
    public struct ZoneData
    {
        public int count; // Количество зон данного типа
        public float radius; // Радиус зон данного типа
        public GameObject prefab; // Префаб зоны
    }
}