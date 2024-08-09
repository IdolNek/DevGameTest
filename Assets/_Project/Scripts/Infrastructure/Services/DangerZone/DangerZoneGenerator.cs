using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.DangerZone
{
    public class DangerZoneGenerator : MonoBehaviour
    {
        // Enum для типов зон
        public GameObject safeZonePrefab;
        public GameObject dangerZonePrefab;
        // Структура для хранения данных о зонах

        // Словарь для хранения данных о зонах
        public Dictionary<ZoneType, ZoneData> zoneDictionary = new Dictionary<ZoneType, ZoneData>();

        // Размеры карты
        public float mapWidth = 30f;
        public float mapHeight = 40f;
        public float minDistanceBetweenZones = 3f; // Минимальное расстояние между краями зон

        private List<Vector2> spawnedZones = new List<Vector2>(); // Список центров уже сгенерированных зон

        private void Awake()
        {
            // Инициализация данных зон
            zoneDictionary.Add(ZoneType.SaveZone, new ZoneData { count = 3, radius = 3f, prefab = safeZonePrefab });
            zoneDictionary.Add(ZoneType.DangerZone, new ZoneData { count = 2, radius = 1f, prefab = dangerZonePrefab });
        }

         public void Initialize()
        {
            GenerateZones();
        }

        private void GenerateZones()
        {
            foreach (var zoneEntry in zoneDictionary)
            {
                ZoneData zoneData = zoneEntry.Value;
                for (int i = 0; i < zoneData.count; i++)
                {
                    Vector2 zonePosition = GetRandomPosition(zoneData.radius);

                    if (zonePosition != Vector2.zero)
                    {
                        // Создаем зону на карте
                        Instantiate(zoneData.prefab, new Vector3(zonePosition.x, 0, zonePosition.y),
                            Quaternion.identity);
                        spawnedZones.Add(zonePosition);
                    }
                    else
                    {
                        Debug.LogWarning($"Не удалось найти подходящее место для зоны типа {zoneEntry.Key}.");
                    }
                }
            }
        }

        private Vector2 GetRandomPosition(float radius)
        {
            int maxAttempts = 100; // Максимальное количество попыток поиска подходящей позиции
            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                // Генерируем случайную позицию в пределах карты, с учетом расстояния до края карты
                float x = Random.Range(-mapWidth / 2f + radius + minDistanceBetweenZones,
                    mapWidth / 2f - radius - minDistanceBetweenZones);
                float z = Random.Range(-mapHeight / 2f + radius + minDistanceBetweenZones,
                    mapHeight / 2f - radius - minDistanceBetweenZones);
                Vector2 newPosition = new Vector2(x, z);

                // Проверяем, не пересекается ли эта зона с другими
                if (IsPositionValid(newPosition, radius))
                {
                    return newPosition;
                }
            }

            // Если не удалось найти подходящее место, возвращаем Vector2.zero
            return Vector2.zero;
        }

        private bool IsPositionValid(Vector2 newPosition, float radius)
        {
            foreach (Vector2 existingPosition in spawnedZones)
            {
                // Вычисляем расстояние между центрами зон
                float distance = Vector2.Distance(newPosition, existingPosition);

                // Если расстояние меньше необходимого, позиция считается недействительной
                if (distance < radius * 2 + minDistanceBetweenZones)
                {
                    return false;
                }
            }

            // Позиция действительна
            return true;
        }
    }
}