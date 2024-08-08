using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;

namespace _Project.Scripts.Character.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 180f; 
        
        private IInputService _inputService;
        private Camera _mainCamera;
        private Vector3? _targetPoint;
        
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _mainCamera = Camera.main;
        }

        public void Initialize(float rotationSpeed) => 
            _rotationSpeed = rotationSpeed;
        
        private void Update()
        {
            // Проверяем, нажата ли кнопка мыши и получаем позицию нажатия
            Vector3? mousePosition = _inputService.GetMouseClickPosition();
        
            if (mousePosition.HasValue)
            {
                // Конвертируем позицию мышки в позицию в мире
                Ray ray = _mainCamera.ScreenPointToRay(mousePosition.Value);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    // Устанавливаем целевую точку для вращения
                    _targetPoint = hitInfo.point;
                }
            }

            if (_targetPoint.HasValue)
            {
                // Вычисляем направление до целевой точки
                Vector3 direction = _targetPoint.Value - transform.position;
                direction.y = 0; // Убираем влияние по оси Y для вращения в плоскости

                // Если направление не равно нулю (есть куда поворачиваться)
                if (direction.sqrMagnitude > 0.01f)
                {
                    // Вычисляем целевой угол поворота
                    Quaternion targetRotation = Quaternion.LookRotation(direction);

                    // Вращаем персонажа постепенно
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

                    // Проверка, достигли ли мы целевой ориентации
                    if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
                    {
                        // Если угол очень мал, то завершаем вращение
                        transform.rotation = targetRotation;
                        _targetPoint = null;
                    }
                }
            }
        }
    }
}