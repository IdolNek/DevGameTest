using UnityEngine;

namespace Assets.Scripts.CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _smoothSpeed = 5;
        [SerializeField] private Vector3 _offset = new Vector3(0, 10, 0);
        
        [SerializeField] private float _mapWidth = 40f;
        [SerializeField] private float _mapHeight = 30f;
        
        private Transform player;

        private Camera _camera;

        private float _cameraHalfWidth;
        private float _cameraHalfHeight;
        private float _minX, _maxX, _minZ, _maxZ;

        private void Start()
        {
            _camera = Camera.main;
            _cameraHalfHeight = _camera.orthographicSize;
            _cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
            _minX = -_mapWidth / 2f + _cameraHalfWidth;
            _maxX = _mapWidth / 2f - _cameraHalfWidth;
            _minZ = -_mapHeight / 2f + _cameraHalfHeight;
            _maxZ = _mapHeight / 2f - _cameraHalfHeight;
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = player.position + _offset;


            float clampedX = Mathf.Clamp(desiredPosition.x, _minX, _maxX);
            float clampedZ = Mathf.Clamp(desiredPosition.z, _minZ, _maxZ);

            Vector3 clampedPosition = new Vector3(clampedX, desiredPosition.y, clampedZ);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }

        public void Follow(GameObject following)
        {
            player = following.transform;
            transform.position = player.position + _offset;
        }
    }
}