using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Player player;
        

        public void OnMovementInput(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector3>();
            player.SetDirection(direction);
        }
    }
}

