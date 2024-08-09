using System.Collections.Generic;
using _Project.Scripts.Infrastructure.GameOption.DangerZone;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.DangerZone
{
    public class DangerZoneGenerator : IDangerZoneGenerator
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IProgressService _progressService;

        private Dictionary<ZoneType, ZoneData> _zoneDictionary;

        private float _mapWidth;
        private float _mapHeight;
        private float _minDistanceBetweenZones = 3f;

        private List<Vector2> spawnedZones = new List<Vector2>();

        public DangerZoneGenerator(IStaticDataService staticDataService, IProgressService progressService)
        {
            _staticDataService = staticDataService;
            _progressService = progressService;
            _zoneDictionary = _staticDataService.ZoneConfigs;
            _mapWidth = staticDataService.GetLevel(_progressService.CurrentLevel).MapWidth;
            _mapHeight = staticDataService.GetLevel(_progressService.CurrentLevel).MapHeight;
        }

        public void GenerateZones()
        {
            foreach (var zoneEntry in _zoneDictionary)
            {
                ZoneData zoneData = zoneEntry.Value;
                for (int i = 0; i < zoneData.count; i++)
                {
                    Vector2 zonePosition = GetRandomPosition(zoneData.radius);

                    if (zonePosition != Vector2.zero)
                    {
                        // Создаем зону на карте
                        GameObject.Instantiate(zoneData.prefab, new Vector3(zonePosition.x, 0, zonePosition.y),
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
                float x = Random.Range(-_mapWidth / 2f + radius + _minDistanceBetweenZones,
                    _mapWidth / 2f - radius - _minDistanceBetweenZones);
                float z = Random.Range(-_mapHeight / 2f + radius + _minDistanceBetweenZones,
                    _mapHeight / 2f - radius - _minDistanceBetweenZones);
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
                if (distance < radius * 2 + _minDistanceBetweenZones)
                {
                    return false;
                }
            }

            // Позиция действительна
            return true;
        }
    }
}