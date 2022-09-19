using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Player _player;
    
        public void OnMovementInput(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector3>();
            _player.SetDirection(direction);
        }
    }
}

