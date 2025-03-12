using Joymg.Platformer2D.WeaponSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.Entities
{
    public class Damageable : MonoBehaviour, IHittable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        public UnityEvent OnHit;
        public UnityEvent OnDie;
        public UnityEvent OnHealthAdded;
        public UnityEvent<int> OnHealthValueChanged;
        public UnityEvent<int> OnInitializeMaxHealth;
        
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                OnHealthValueChanged?.Invoke(currentHealth);
            }
        }

        public void Initialize(int health)
        {
            maxHealth = health;
            OnInitializeMaxHealth?.Invoke(maxHealth);
            CurrentHealth = maxHealth;
        }

        public void GetHit(GameObject agentGameObject, int damage)
        {
            PerformHit(damage);
        }

        private void PerformHit(int damage)
        {
            CurrentHealth -= damage;
            OnHit?.Invoke();
            if (CurrentHealth  <=  0)
            {
                OnDie?.Invoke();
            }
        }

        public void AddHealth(int value)
        {
            CurrentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
            OnHealthAdded?.Invoke();
        }
    }
}