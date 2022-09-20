using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Params")] [SerializeField] private float _moveSpeed;

    [Header("Checkers")] [SerializeField] private CheckCircleOverLap _attackRange;


    private Rigidbody _rigidbody;
    private Vector3 _direction;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void FixedUpdate()
    {
        var xVelocity = CalculateXVelocity();
        var zVelocity = CalculateZVelocity();
        _rigidbody.velocity = new Vector3(xVelocity, 0, zVelocity);
    }

    protected virtual float CalculateXVelocity()
    {
        return _direction.x * _moveSpeed;
    }

    protected virtual float CalculateZVelocity()
    {
        return _direction.z * _moveSpeed;
    }


    public void OnDoAttack()
    {
        _attackRange.Check();
    }
}

