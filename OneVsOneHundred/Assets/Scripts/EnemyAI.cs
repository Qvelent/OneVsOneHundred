using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private ColliderCheck _vision;
    [SerializeField] private ColliderCheck _canAttack;

    [SerializeField] private float _alarmDelay = 0.5f;
    [SerializeField] private float _attackCooldown = 1f;
    [SerializeField] private float _missPlayerCooldown = 0.5f;

    [SerializeField] private float _horizontalTreshold = 0.2f;


    private IEnumerator _current;
    private GameObject _target;
    private EnemyController _enemyController;

    private Animator _animator;
    private bool _isDead;


    private static readonly int IsDieKey = Animator.StringToHash("is-dead");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnPlayerVision(GameObject go)
    {
        if (_isDead) return;

        _target = go;
        StartCoroutine(AgroToPlayer());
    }

    private IEnumerator AgroToPlayer()
    {
        LookAtPlayer();
        yield return new WaitForSeconds(_alarmDelay);

        StartState(GoToPlayer());
    }

    private void LookAtPlayer()
    {
        var direction = GetDirectionToTarget();
    }

    private IEnumerator GoToPlayer()
    {
        while (_vision.IsTouchingLayer)
        {
            if (_canAttack.IsTouchingLayer)
            {
                StartState(Attack());
            }
            else
            {
                var horizontalDelta = Mathf.Abs(_target.transform.position.x - transform.position.x);
                if (horizontalDelta <= _horizontalTreshold)
                    _enemyController.SetDirection(Vector2.zero);
                else
                    SetDirectionToTarget();
            }

            yield return null;
        }

        _enemyController.SetDirection(Vector2.zero);
        yield return new WaitForSeconds(_missPlayerCooldown);
    }

    private IEnumerator Attack()
    {
        while (_canAttack.IsTouchingLayer)
        {
            yield return new WaitForSeconds(_attackCooldown);
        }

        StartState(GoToPlayer());

    }

    private void SetDirectionToTarget()
    {
        var direction = GetDirectionToTarget();
        _enemyController.SetDirection(direction);
    }

    private Vector2 GetDirectionToTarget()
    {
        var direction = _target.transform.position - transform.position;
        direction.y = 0;
        return direction.normalized;
    }

    private void StartState(IEnumerator coroutine)
    {
        _enemyController.SetDirection(Vector3.zero);

        if (_current != null)
        {
            StopCoroutine(_current);
        }

        _current = coroutine;
        StartCoroutine(coroutine);
    }

    public void OnDie()
    {
        _isDead = true;
        _animator.SetBool(IsDieKey, true);

        _enemyController.SetDirection(Vector3.zero);
        if (_current != null)
        {
            StopCoroutine(_current);
        }
    }
}

