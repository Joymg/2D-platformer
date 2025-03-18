using System;
using UnityEngine;
using UnityEngine.Events;

namespace Joymg.Platformer2D.AI.Behaviours
{
    public class AIRangeDetector : MonoBehaviour
    {
        public LayerMask targetLayerMask;
        [Range(0.1f, 1f)]
        public float radius;
        public bool IsPlayerInRange { get; private set; }
        public UnityEvent<GameObject> OnPlayerInRange;

        [Header("Gizmo Parameters")] 
        public Color gizmoColor = Color.magenta;
        public bool showGizmos = true;

        private void FixedUpdate()
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, targetLayerMask);
            IsPlayerInRange = collider;
            if (IsPlayerInRange)
                OnPlayerInRange?.Invoke(collider.gameObject);
                
        }

        private void OnDrawGizmos()
        {
            if (showGizmos)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(transform.position, radius);
            }
        }
    }
}