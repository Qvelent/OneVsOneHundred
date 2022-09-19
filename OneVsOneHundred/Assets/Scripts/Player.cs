using UnityEngine;

namespace Scripts
{
    public class Player : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private float moveSpeed;

        private Rigidbody _rigidbody;
        private Vector3 _direction;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void FixedUpdate()
        {
            var xVelocity = CalculateXVelocity();
            var zVelocity = CalculateZVelocity();
            _rigidbody.velocity = new Vector3(xVelocity, 0, zVelocity);
            
        }

        private float CalculateZVelocity()
        {
            return _direction.z * moveSpeed;
        }

        private float CalculateXVelocity()
        {
            return _direction.x * moveSpeed;
        }
        
        
        
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}

