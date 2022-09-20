using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Player player;

        private SpawnComponent _spawnComponent;

        private void Awake()
        {
            _spawnComponent = GetComponent<SpawnComponent>();
        }


        public void OnMovementInput(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector3>();
            player.SetDirection(direction);
        }

        public void OnFireInput(InputAction.CallbackContext context)
        {
            _spawnComponent.Spawn();
        }
    }
}

