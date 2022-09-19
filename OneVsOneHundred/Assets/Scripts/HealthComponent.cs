using System;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public class HealthComponent : MonoBehaviour
    {

        [SerializeField] private int _maxHealth;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] public UnityEvent _onDie;

        public int Health => _maxHealth;

        public void ModifyHealth(int hpDelta)
        {
            if (_maxHealth <= 0) return;
            _maxHealth += hpDelta;

            if (hpDelta < 0)
            {
                _onDamage?.Invoke();
                Debug.Log("Оставшееся хп: " + _maxHealth);
            }

            if (_maxHealth <= 0)
            {
                _onDie?.Invoke();
            }


        }
    }
}    
