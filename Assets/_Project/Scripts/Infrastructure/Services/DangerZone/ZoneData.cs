using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.DangerZone
{
    [Serializable]
    public struct ZoneData
    {
        public int count; // Количество зон данного типа
        public float radius; // Радиус зон данного типа
        public GameObject prefab; // Префаб зоны
    }
}