using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;

namespace _Project.Scripts.Character.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 4f;

        private CharacterController _characterController;
        private IInputService _inputService;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Initialize(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        private void Start() => 
            _characterController = GetComponent<CharacterController>();

        private void Update()
        {
            if(_inputService == null) return;
            
            Vector2 axis = _inputService.Axis;

            Vector3 movement = new Vector3(axis.x, 0, axis.y) * _moveSpeed;

            _characterController.Move(movement * Time.deltaTime);
        }
    }
}