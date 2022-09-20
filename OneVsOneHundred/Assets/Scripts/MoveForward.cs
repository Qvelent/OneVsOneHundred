using System;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed = 40f;


    private void Update()
    {
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
    }

    private void OnCollisionEnter()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
