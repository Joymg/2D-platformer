using System;
using Joymg.Platformer2D.Entities;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.Entities.PickUps
{
    public abstract class PickUp : MonoBehaviour
    {
        private static readonly string PlayerLayerKey = "Player"; 
        
        protected SpriteRenderer _spriteRenderer;
        
        public LayerMask _groundLayerMask;
        [SerializeField] private BoxCollider2D _collider2D;
        [SerializeField] protected Color gizmoColor = Color.magenta;
        public UnityEvent OnGrounded;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _collider2D = GetComponentInChildren<BoxCollider2D>();
        }

        public abstract void Collect(Agent agent);

        private void OnTriggerEnter2D(Collider2D other)
        {
            //Method is called because player collider is a trigger and it calls both OnTrigger methods
            
            if (other.gameObject.layer != LayerMask.NameToLayer(PlayerLayerKey)) return;
            
            Collect(other.GetComponent<Agent>());
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((1 << other.gameObject.layer & _groundLayerMask) != 0)
            {
                OnGrounded?.Invoke();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(_collider2D.bounds.center, _collider2D.bounds.size);
        }
    }
}
